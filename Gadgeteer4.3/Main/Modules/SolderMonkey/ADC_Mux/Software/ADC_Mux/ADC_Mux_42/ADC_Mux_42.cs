﻿using System;
using Microsoft.SPOT;

using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using GTI = Gadgeteer.Interfaces;

namespace Gadgeteer.Modules.SolderMonkey
{
    /// <summary>
    /// A ADC_Mux module for Microsoft .NET Gadgeteer
    /// </summary>
    public class ADC_Mux : GTM.Module
    {
        // Note: A constructor summary is auto-generated by the doc builder.
        /// <summary></summary>
        /// <param name="socketNumber">The socket that this module is plugged in to.</param>
        public ADC_Mux(int socketNumber)
        {
            // This finds the Socket instance from the user-specified socket number.  
            // This will generate user-friendly error messages if the socket is invalid.
            // If there is more than one socket on this module, then instead of "null" for the last parameter, 
            // put text that identifies the socket to the user (e.g. "S" if there is a socket type S)
            Socket socket = Socket.GetSocket(socketNumber, true, this, null);

            addr0 = new GTI.DigitalOutput(socket, Socket.Pin.Three, false, null);
            addr1 = new GTI.DigitalOutput(socket, Socket.Pin.Six, false, null);

            this.analogA = new GTI.AnalogInput(socket, Socket.Pin.Four, this);
            this.analogB = new GTI.AnalogInput(socket, Socket.Pin.Five, this);
        }

        /// <summary>
        /// ID matching number printed next to screwterminal on module
        /// </summary>
        public enum ChannelID
        {
            /// <summary>
            /// Channel0
            /// </summary>
            A_In0 = 0,
            /// <summary>
            /// Channel1
            /// </summary>
            A_In1 = 1,
            /// <summary>
            /// Channel2
            /// </summary>
            A_In2 = 2,
            /// <summary>
            /// Channel3
            /// </summary>
            A_In3 = 3,
            /// <summary>
            /// Channel4
            /// </summary>
            A_In4 = 4,
            /// <summary>
            /// Channel5
            /// </summary>
            A_In5 = 5,
            /// <summary>
            /// Channel6
            /// </summary>
            A_In6 = 6,
            /// <summary>
            /// Channel7
            /// </summary>
            A_In7 = 7
        }

        private GTI.DigitalOutput addr0;
        private GTI.DigitalOutput addr1;

        private GTI.AnalogInput analogA;
        private GTI.AnalogInput analogB;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public double ReadVoltage(ChannelID ID)
        {
            switch (ID)
            {
                case ChannelID.A_In0:
                    {
                        addr0.Write(true);
                        addr1.Write(false);

                        return analogA.ReadVoltage();
                    }
                case ChannelID.A_In1:
                    {
                        addr0.Write(false);
                        addr1.Write(false);

                        return analogA.ReadVoltage();
                    }
                case ChannelID.A_In2:
                    {
                        addr0.Write(true);
                        addr1.Write(true);

                        return analogA.ReadVoltage();
                    }
                case ChannelID.A_In3:
                    {
                        addr0.Write(false);
                        addr1.Write(true);

                        return analogA.ReadVoltage();
                    }
                case ChannelID.A_In4:
                    {
                        addr0.Write(true);
                        addr1.Write(false);

                        return analogB.ReadVoltage();
                    }
                case ChannelID.A_In5:
                    {
                        addr0.Write(false);
                        addr1.Write(false);

                        return analogB.ReadVoltage();
                    }
                case ChannelID.A_In6:
                    {
                        addr0.Write(true);
                        addr1.Write(true);

                        return analogB.ReadVoltage();
                    }
                case ChannelID.A_In7:
                    {
                        addr0.Write(true);
                        addr1.Write(false);

                        return analogB.ReadVoltage();
                    }
                default: // cant get here...
                    return 0;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public double ReadProportion(ChannelID ID)
        {
            switch (ID)
            {
                case ChannelID.A_In0:
                    {
                        addr0.Write(true);
                        addr1.Write(false);

                        return analogA.ReadProportion();
                    }
                case ChannelID.A_In1:
                    {
                        addr0.Write(false);
                        addr1.Write(false);

                        return analogA.ReadProportion();
                    }
                case ChannelID.A_In2:
                    {
                        addr0.Write(true);
                        addr1.Write(true);

                        return analogA.ReadProportion();
                    }
                case ChannelID.A_In3:
                    {
                        addr0.Write(false);
                        addr1.Write(true);

                        return analogA.ReadProportion();
                    }
                case ChannelID.A_In4:
                    {
                        addr0.Write(true);
                        addr1.Write(false);

                        return analogB.ReadProportion();
                    }
                case ChannelID.A_In5:
                    {
                        addr0.Write(false);
                        addr1.Write(false);

                        return analogB.ReadProportion();
                    }
                case ChannelID.A_In6:
                    {
                        addr0.Write(true);
                        addr1.Write(true);

                        return analogB.ReadProportion();
                    }
                case ChannelID.A_In7:
                    {
                        addr0.Write(false);
                        addr1.Write(true);

                        return analogB.ReadProportion();
                    }
                default: // cant get here...
                    return 0;
            }
        }
    }
}
