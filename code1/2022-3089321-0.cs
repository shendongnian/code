    public partial class App
    {
        [DllImport("user32")]
        private static extern int OpenIcon(IntPtr hWnd);
    
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var p = Process
               .GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                foreach (var t in p.Where(t => t.MainWindowHandle != IntPtr.Zero))
                {
                    OpenIcon(t.MainWindowHandle);
                    SetForegroundWindow(t.MainWindowHandle);
                    Current.Shutdown();
                    return;
                }
    
                // there is a chance the user tries to click on the icon repeatedly
                // and the process cannot be discovered yet
                bool createdNew;
                var mutex = new Mutex(true, "MyAwesomeApp", 
                   out createdNew);  // must be a variable, though it is unused - 
                // we just need a bit of time until the process shows up
                if (!createdNew)
                {
                    Current.Shutdown();
                    return;
                }
    
                new Bootstrapper().Run();
            }
        }
