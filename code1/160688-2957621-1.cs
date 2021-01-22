    using System;
    using System.Runtime.InteropServices;
    class Program
    {
         internal delegate bool DelegBeep(uint iFreq, uint iDuration);
         [DllImport("kernel32.dll")]
         internal static extern IntPtr LoadLibrary(String dllname);
         [DllImport("kernel32.dll")]
         internal static extern IntPtr GetProcAddress(IntPtr hModule,String procName);
         static void Main()
         {
              IntPtr kernel32 = LoadLibrary( "Kernel32.dll" );
              IntPtr procBeep = GetProcAddress( kernel32, "Beep" );
              DelegBeep delegBeep = Marshal.GetDelegateForFunctionPointer(procBeep , typeof( DelegBeep ) ) as DelegBeep;
              delegBeep(100,100);
         }
    }
