     using System;
     using System.Runtime.InteropServices;
     public static int IdleTime() //In seconds
        {
            LASTINPUTINFO lastinputinfo = new LASTINPUTINFO();
            lastinputinfo.cbSize = Marshal.SizeOf(lastinputinfo);
            GetLastInputInfo(ref lastinputinfo);
            return (((Environment.TickCount & int.MaxValue) - (lastinputinfo.dwTime & int.MaxValue)) & int.MaxValue) / 1000;
        }
