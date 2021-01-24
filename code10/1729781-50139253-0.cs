    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    #endregion
    
    namespace MonchaTestSDK {
    
        public class Program {
    
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int OpenDll();
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern void CloseDll();
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int SearchForNETDevices(ref UInt32 pNumOfFoundDevs);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int CreateDeviceList(ref UInt32 pDeviceCount);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int GetDeviceIdentifier(UInt32 deviceIndex, out IntPtr ppDeviceName);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int SendFrame(UInt32 deviceIndex, LaserPoint[] pData, UInt32 numOfPoints, UInt32 scanrate);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int CanSendNextFrame(UInt32 deviceIndex, ref bool pCanSend);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // OK
            public static extern int SendBlank(UInt32 deviceIndex, UInt16 x, UInt16 y);
            [DllImport("..\\..\\dll\\StclDevices.dll", CallingConvention = CallingConvention.Cdecl)]                                        // FAILS
            public static extern int GetDeviceInfo(UInt32 deviceIndex, ref DeviceInfo pDeviceInfo);
    
            [StructLayout(LayoutKind.Sequential, Pack=1)]
            public struct LaserPoint {
                public UInt16 x;
                public UInt16 y;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
                public byte[] colors;
            }
    
            [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
            public struct DeviceInfo {
                public UInt32 maxScanrate;
                public UInt32 minScanrate;
                public UInt32 maxNumOfPoints;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string type;
            }
    
            public static void Main(string[] args) {
                Console.WriteLine("Moncha SDK\n");
    
                OpenDll();
                Console.WriteLine("StclDevices.dll is open.");
    
                UInt32 deviceCount1 = 0;
                int r1 = SearchForNETDevices(ref deviceCount1);
                Console.WriteLine("SearchForNETDevices() [" + r1+"]: "+deviceCount1);
    
                UInt32 deviceCount2 = 0;
                int r2 = CreateDeviceList(ref deviceCount2);
                Console.WriteLine("CreateDeviceList() ["+r2+"]: "+deviceCount2);
    
                IntPtr pString;
                int r3 = GetDeviceIdentifier(0, out pString);
                string devname = Marshal.PtrToStringUni(pString);
                Console.WriteLine("GetDeviceIdentifier() ["+r3+"]: "+devname);
    
                DeviceInfo pDevInfo = new DeviceInfo();
                int r4 = GetDeviceInfo(0, ref pDevInfo);
                Console.WriteLine("GetDeviceInfo() ["+r4+"]: ");
                Console.WriteLine("  - min: "+pDevInfo.minScanrate);
                Console.WriteLine("  - max: " + pDevInfo.maxScanrate);
                Console.WriteLine("  - points: " + pDevInfo.maxNumOfPoints);
                Console.WriteLine("  - type: " + pDevInfo.type);
    
                const UInt32 numOfPts = 600;
    
                do {
                    while(!Console.KeyAvailable) {
                        for(UInt16 j=0; j< deviceCount1; j++) {
    
                            bool canSend = false;
                            CanSendNextFrame(j, ref canSend);
                            if(!canSend) {
                                continue;
                            }
    
                            LaserPoint[] points = new LaserPoint[numOfPts];
                            float t = (Environment.TickCount % 2000) / 2000.0f;
                            for(int i=0; i<numOfPts; i++) {
                                points[i].x = (UInt16)(16384 + 32768 * i / numOfPts);
                                points[i].y = (UInt16)(16384 + 32768 * t);
                                points[i].colors = new byte[6];
                                points[i].colors[0] = 255;
                                points[i].colors[1] = 0;
                                points[i].colors[2] = 0;
                                points[i].colors[3] = 0;
                                points[i].colors[4] = 0;
                                points[i].colors[5] = 0;
                            }
    
                            SendFrame(j, points, numOfPts, 30000);
    
                        }
                        Thread.Sleep(5);
    
                    }
                } while(Console.ReadKey(true).Key != ConsoleKey.Escape);
    
                Thread.Sleep(100);
                CloseDll();
    
            }
    
        }
    }
