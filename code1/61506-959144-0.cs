    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
    namespace DynamicX86
    {
        class Program
        {
            const uint PAGE_EXECUTE_READWRITE = 0x40;
            const uint MEM_COMMIT = 0x1000;
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
    
            private delegate int IntReturner();
    
            static void Main(string[] args)
            {
                List<byte> bodyBuilder = new List<byte>();
                bodyBuilder.Add(0xb8);
                bodyBuilder.AddRange(BitConverter.GetBytes(42));
                bodyBuilder.Add(0xc3);
                byte[] body = bodyBuilder.ToArray();
                IntPtr buf = VirtualAlloc(IntPtr.Zero, (uint)body.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
                Marshal.Copy(body, 0, buf, body.Length);
    
                IntReturner ptr = ptr = (IntReturner)Marshal.GetDelegateForFunctionPointer(buf, typeof(IntReturner));
                Console.WriteLine(ptr());
            }
        }
    }
