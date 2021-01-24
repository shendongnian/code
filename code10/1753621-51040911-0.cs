    using System;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TEST
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string aString;
        }
        class Program
        {
            static void Main()
            {
                TEST test = new TEST();
                test.aString = "1234567890123456789012345";
                int    size = Marshal.SizeOf(test);
                byte[] arr  = new byte[size];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(test, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
                Console.WriteLine("Bytes: " + string.Join(", ", arr));
                test = Marshal.PtrToStructure<TEST>(ptr);
                Marshal.FreeHGlobal(ptr);
                Console.WriteLine(test.aString); // Prints "1234567890123456789" - only 19 characters.
            }
        }
    }
