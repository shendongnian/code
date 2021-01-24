    ////////////////////////////////////////////////////////////////////////////////
    //                                                                            //
    //   Wireless Communication Library 7                                         //
    //                                                                            //
    //   Copyright (C) 2006-2019 Mike Petrichenko                                 //
    //                           Soft Service Company                             //
    //                           All Rights Reserved                              //
    //                                                                            //
    //   http://www.btframework.com                                               //
    //                                                                            //
    //   support@btframework.com                                                  //
    //   shop@btframework.com                                                     //
    //                                                                            //
    // -------------------------------------------------------------------------- //
    //                                                                            //
    //   WCL Bluetooth Framework: Trun Bluetooth On/Off.                          //
    //                                                                            //
    //   Requires Windows 10.                                                     //
    //   You can use this code as you want but copyright and this unit            //
    //   header must be included in your project.                                 //
    //                                                                            //
    ////////////////////////////////////////////////////////////////////////////////
    using System;
    using System.Runtime.InteropServices;
    
    namespace Bluetooth
    {
        /// <summary> The Bluetooth Radio state. </summary>
        public enum BluetoothRadioState
        {
            /// <summary> Radio is turned ON. </summary>
            rsOn,
            /// <summary> Radio is turned OFF. </summary>
            tsOff
        };
    
        /// <summary> The class includes functions to control Bluetooth Radio. </summary>
        public static class BtControl
        {
            private static Guid CLSID_BluetoothRadioManager = new Guid("{afd198ac-5f30-4e89-a789-5ddf60a69366}");
            private const UInt32 CLSCTX_INPROC_SERVER = 1;
    
            private enum DEVICE_RADIO_STATE : uint
            {
                DRS_RADIO_ON = 0,
                DRS_SW_RADIO_OFF = 1,
                DRS_HW_RADIO_OFF = 2,
                DRS_SW_HW_RADIO_OFF = 3,
                DRS_HW_RADIO_ON_UNCONTROLLABLE = 4,
                DRS_RADIO_INVALID = 5,
                DRS_HW_RADIO_OFF_UNCONTROLLABLE = 6,
                DRS_RADIO_MAX = DRS_HW_RADIO_OFF_UNCONTROLLABLE
            };
    
            private enum SYSTEM_RADIO_STATE : uint
            {
                SRS_RADIO_ENABLED = 0,
                SRS_RADIO_DISABLED = 1
            };
    
            [ComImport]
            [Guid("70AA1C9E-F2B4-4C61-86D3-6B9FB75FD1A2")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            private interface IRadioInstance
            {
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetRadioManagerSignature(
                    [param: Out] out Guid pguidSignature);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetInstanceSignature(
                    [param: MarshalAs(UnmanagedType.BStr), Out] out String pbstrId);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetFriendlyName(
                    [param: MarshalAs(UnmanagedType.U4), In] UInt32 lcid,
                    [param: MarshalAs(UnmanagedType.BStr), Out] out String pbstrName);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetRadioState(
                    [param: Out] out DEVICE_RADIO_STATE pRadioState);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 SetRadioState(
                    [param: In] DEVICE_RADIO_STATE radioState,
                    [param: MarshalAs(UnmanagedType.U4), In] UInt32 uTimeoutSec);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.Bool)]
                Boolean IsMultiComm();
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.Bool)]
                Boolean IsAssociatingDevice();
            };
    
            [ComImport]
            [Guid("E5791FAE-5665-4E0C-95BE-5FDE31644185")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            private interface IRadioInstanceCollection
            {
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetCount(
                    [param: MarshalAs(UnmanagedType.U4), Out] out UInt32 pcInstance);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetAt(
                    [param: MarshalAs(UnmanagedType.U4), In] UInt32 uIndex,
                    [param: MarshalAs(UnmanagedType.Interface), Out] out IRadioInstance ppRadioInstance);
            };
    
            [ComImport]
            [Guid("6CFDCAB5-FC47-42A5-9241-074B58830E73")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            private interface IMediaRadioManager
            {
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 GetRadioInstances(
                    [param: MarshalAs(UnmanagedType.Interface), Out] out IRadioInstanceCollection ppCollection);
    
                [PreserveSig]
                [return: MarshalAs(UnmanagedType.I4)]
                Int32 OnSystemRadioStateChange(
                    [param: In] SYSTEM_RADIO_STATE sysRadioState,
                    [param: MarshalAs(UnmanagedType.U4), In] UInt32 uTimeoutSec);
            };
    
            [DllImport("ole32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.I4)]
            private static extern Int32 CoCreateInstance(
                [param: In] ref Guid rclsid,
                [param: MarshalAs(UnmanagedType.SysInt), In] IntPtr pUnkOuter,
                [param: MarshalAs(UnmanagedType.U4), In] UInt32 dwClsContext,
                [param: In] ref Guid riid,
               [param: MarshalAs(UnmanagedType.Interface), Out] out IMediaRadioManager ppv);
    
            private static Boolean Succeeded(Int32 Status)
            {
                return ((Status & 0x80000000) == 0);
            }
    
            private static Boolean GetRadioInstance(out IRadioInstance Radio)
            {
                Boolean Result = false;
                Radio = null;
    
                IMediaRadioManager RadioMan;
                Guid Iid = typeof(IMediaRadioManager).GUID;
                Int32 Res = CoCreateInstance(ref CLSID_BluetoothRadioManager, IntPtr.Zero,
                    CLSCTX_INPROC_SERVER, ref Iid, out RadioMan);
                if (Succeeded(Res))
                {
                    IRadioInstanceCollection Instances;
                    if (Succeeded(RadioMan.GetRadioInstances(out Instances)))
                    {
                        UInt32 Cnt;
                        if (Succeeded(Instances.GetCount(out Cnt)) && Cnt > 0)
                            Result = Succeeded(Instances.GetAt(0, out Radio));
    
                        Instances = null;
                    }
    
                    RadioMan = null;
                }
    
                return Result;
            }
    
            /// <summary> Gets the current Bluetooth Radio state. </summary>
            /// <param name="State"> If the function completed with success on output
            ///   indicates the current Bluetooth Radio State. </param>
            /// <returns> The function returns <c>True</c> if operation has been completed
            ///   with success. Otherwise the function returns <c>False</c>. </returns>
            /// <remarks> If is required that your application targets Windows platform.
            ///   That means that on x64 bit Windows your application must run as x64.
            ///   Otherwise the function returns <c>False</c>. That is because of
            ///   Windows Bluetooth Manager implementation. </remarks>
            /// <seealso cref="BluetoothRadioState" />
            public static Boolean GetBluetoothState(out BluetoothRadioState State)
            {
                State = BluetoothRadioState.tsOff;
    
                IRadioInstance Radio;
                Boolean Result = GetRadioInstance(out Radio);
                if (Result)
                {
                    DEVICE_RADIO_STATE SysState;
                    if (Succeeded(Radio.GetRadioState(out SysState)))
                    {
                        if (SysState == DEVICE_RADIO_STATE.DRS_RADIO_ON)
                            State = BluetoothRadioState.rsOn;
                        Result = true;
                    }
                    Radio = null;
                }
                return Result;
            }
    
            /// <summary> Switch Bluetooth Radio On and Off. </summary>
            /// <param name="State"> The new Bluetooth Radio state. </param>
            /// <returns> The function returns <c>True</c> if operation has been completed
            ///   with success. Otherwise the function returns <c>False</c>. </returns>
            /// <remarks> If is required that your application targets Windows platform.
            ///   That means that on x64 bit Windows your application must run as x64.
            ///   Otherwise the function returns <c>False</c>. That is because of
            ///   Windows Bluetooth Manager implementation. </remarks>
            /// <seealso cref="BluetoothRadioState" />
            public static Boolean SwitchBluetooth(BluetoothRadioState State)
            {
                IRadioInstance Radio;
                Boolean Result = GetRadioInstance(out Radio);
                if (Result)
                {
                    DEVICE_RADIO_STATE SysState;
                    if (State == BluetoothRadioState.rsOn)
                        SysState = DEVICE_RADIO_STATE.DRS_RADIO_ON;
                    else
                        SysState = DEVICE_RADIO_STATE.DRS_SW_RADIO_OFF;
                    Result = Succeeded(Radio.SetRadioState(SysState, 10));
                    Radio = null;
                }
                return Result;
            }
        };
    }
