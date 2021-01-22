    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
              static extern bool ReadProcessMemory(
              IntPtr hProcess,
              IntPtr lpBaseAddress,
              [Out] byte[] lpBuffer,
              int dwSize,
              out int lpNumberOfBytesRead
            );
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        static void Main(string[] args)
        {
            Process[] procs = Process.GetProcessesByName("explorer");
            if (procs.Length <= 0)  //proces not found
                return; //can replace with exit nag(message)+exit;
            IntPtr p = OpenProcess(0x10 | 0x20, true, procs[0].Id); //0x10-read 0x20-write
            uint PTR = 0x0; //begin of memory
            byte[] bit2search1 = {0xEB ,0x20,0x68,0x21,0x27,0x65}; //your bit array until ??
            int k = 1;  //numer of missing array (??)
            byte[] bit2search2 = {0x21,0x64,0xA1};//your bit array after ??
            byte[] buff = new byte[bit2search1.Length+1+bit2search2.Length];    //your array lenght;
            int bytesReaded;
            bool finded = false;
            while (PTR != 0xFF000000)   //end of memory // u can specify to read less if u know he does not fill it all
            {
                ReadProcessMemory(p, (IntPtr)PTR, buff, buff.Length, out bytesReaded);
                if (SpecialByteCompare(buff, bit2search1,bit2search2,k))
                {
                    //do your stuff
                    finded = true;
                    break;
                }
                PTR += 0x1;
            }
            if (!finded)
                Console.WriteLine("sry no byte array found");
        }
        private static bool SpecialByteCompare(byte[] b1, byte[] b2, byte[] b3, int k)  //readed memory, first byte array, second byte array, number of missing byte's
        {
            if (b1.Length != (b2.Length + k + b3.Length))
                return false;
            for (int i = 0; i < b2.Length; i++)
            {
                if (b1[i] != b2[i])
                    return false;
            }
            for (int i = 0; i < b3.Length; i++)
            {
                if (b1[b2.Length + k + i] != b3[i])
                    return false;
            }
            return true;
        }
    }
}
