    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
    
    
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, 
            UInt32 Msg, 
            IntPtr wParam, 
            IntPtr lParam);
        private const UInt32 WM_SYSCOMMAND = 0x112;
        private const UInt32 SC_RESTORE = 0xf120;
    
        private const string OnScreenKeyboardExe = "osk.exe";
    
        [STAThread]
        static void Main(string[] args)
        {
            Process[] p = Process.GetProcessesByName(
                Path.GetFileNameWithoutExtension(OnScreenKeyboardExe));
    
            if (p.Length == 0)
            {
                // we must start osk from an MTA thread
                if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                {
                    ThreadStart start = new ThreadStart(StartOsk);
                    Thread thread = new Thread(start);
                    thread.SetApartmentState(ApartmentState.MTA);
                    thread.Start();
                    thread.Join();
                }
                else
                {
                    StartOsk();
                }
            }
            else
            {
                // there might be a race condition if the process terminated 
                // meanwhile -> proper exception handling should be added
                //
                SendMessage(p[0].MainWindowHandle, 
                    WM_SYSCOMMAND, new IntPtr(SC_RESTORE), new IntPtr(0));
            }
        }
    
        static void StartOsk()
        {
            IntPtr ptr = new IntPtr(); ;
            bool sucessfullyDisabledWow64Redirect = false;
    
            // Disable x64 directory virtualization if we're on x64,
            // otherwise keyboard launch will fail.
            if (System.Environment.Is64BitOperatingSystem)
            {
                sucessfullyDisabledWow64Redirect = 
                    Wow64DisableWow64FsRedirection(ref ptr);
            }
    
    
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = OnScreenKeyboardExe;
            // We must use ShellExecute to start osk from the current thread
            // with psi.UseShellExecute = false the CreateProcessWithLogon API 
            // would be used which handles process creation on a separate thread 
            // where the above call to Wow64DisableWow64FsRedirection would not 
            // have any effect.
            //
            psi.UseShellExecute = true;
            Process.Start(psi);
    
            // Re-enable directory virtualisation if it was disabled.
            if (System.Environment.Is64BitOperatingSystem)
                if (sucessfullyDisabledWow64Redirect)
                    Wow64RevertWow64FsRedirection(ptr);
        }
    }
