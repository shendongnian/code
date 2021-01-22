    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(
            IntPtr hWnd, 
            UInt32 Msg, 
            IntPtr wParam, 
            IntPtr lParam);
        private const UInt32 WM_SYSCOMMAND = 0x112;
        private const UInt32 SC_RESTORE = 0xf120;
    
        private const string OnScreenKeyboardExe = "osk.exe";
    
        static void Main(string[] args)
        {
            Process[] p = Process.GetProcessesByName(
                Path.GetFileNameWithoutExtension(OnScreenKeyboardExe));
            if (p.Length == 0)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = OnScreenKeyboardExe;
                if (System.Environment.Is64BitOperatingSystem)
                    psi.Verb = "runas";
                Process.Start(psi);
            }
            else
            {
                // there might be a race condition if the process 
                // terminated meanwhile -> proper exception 
                // handling should be added
                //
                SendMessage(p[0].MainWindowHandle, 
                    WM_SYSCOMMAND, 
                    new IntPtr(SC_RESTORE), 
                    new IntPtr(0));
            }
        }
    }
