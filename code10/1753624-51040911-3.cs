    using System;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TEST
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public char[] aString;
        }
        class Program
        {
            static void Main()
            {
                TEST test = new TEST();
                test.aString = "1234567890123456789012345".ToCharArray();
                int    size = Marshal.SizeOf(test);
                byte[] arr  = new byte[size];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(test, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Console.WriteLine("Bytes: " + string.Join(", ", arr));
                test = Marshal.PtrToStructure<TEST>(ptr);
                Marshal.FreeHGlobal(ptr);
                Console.WriteLine(new string(test.aString)); // Prints "12345678901234567890" - all 20 characters.
            }
        }
    }
