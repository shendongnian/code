    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                SInfo s = new SInfo();
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(s));
                Marshal.StructureToPtr(s, ptr, true);
                byte[] buffer = new byte[Marshal.SizeOf(s)];
                Marshal.Copy(ptr, buffer, 0, Marshal.SizeOf(s));
                Test test = new Test();
                SInfo sinto = test.FromByteArray<SInfo>(buffer);
            }
        }
        public class Test
        {
            public T FromByteArray<T>(byte[] _array)
            {
                BinaryReader _reader = new BinaryReader(new MemoryStream(_array));
                GCHandle handle = GCHandle.Alloc(_array, GCHandleType.Pinned);
                T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();
                return theStructure;
            }
        }
        [System.Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SInfo
        {
            public byte STX;
            public short Length;
            public short ID;
            public byte CMD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public float[] arrAxis;
            //public float AxisX;
            //public float AxisY;
            //public float AxisZ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public float[] arrQuat;
            //public float QuaternionX;
            //public float QuaternionY;
            //public float QuaternionZ;
            //public float QuaternionW;
            public byte State;
            public short State2;
            public byte CRC;
        }
     
     
    }
