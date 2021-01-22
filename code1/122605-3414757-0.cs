    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    namespace UnsafeWriting
    {
        class Program
        {
            static void Main(string[] args)
            {
                ushort[] someArray = new ushort[20];
                for (int i = 0; i < 20; i++) { someArray[i] = (ushort)i; }
                using (FileStream stm = new FileStream("output.bin", FileMode.Create))
                {
                    unsafe
                    {
                        fixed (ushort* dataPtr = &someArray[0])
                        {
                            stm.Write(dataPtr, someArray.Length);
                        }
                    }
                }
            }
        }
        public static class Extensions
        {
            public static unsafe void Write(this Stream stm, ushort* data, int count)
            {
                count *= 2;
                byte[] arr = new byte[count];
                Marshal.Copy(new IntPtr(data), arr, 0, count);
                stm.Write(arr, 0, count);
            }
        }
    }
