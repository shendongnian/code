     Process[] processes = Process.GetProcessesByName(m.ProcessName);
                                        if (processes != null && processes.Length > 0)
                                        {
                                            Process process = processes[0];
                                            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                                            process.Refresh();
                                            if (process.MainWindowHandle != IntPtr.Zero)
                                            { // process.mainwindows handle is needed for you
