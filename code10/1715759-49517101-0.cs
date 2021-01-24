                    var thread = new Thread(() => {
                        try
                        {
                            Thread.Sleep(500);
                            var me = Process.GetCurrentProcess();
                            var myProcesses = Process.GetProcessesByName(me.ProcessName);
                            foreach (var p in myProcesses)
                            {
                                if (p.Id != me.Id)
                                {
                                    SwitchToThisWindow(p.MainWindowHandle, true);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Exception(e);
                        }});
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
....
        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
