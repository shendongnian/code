    IntPtr hwnd = IntPtr.Zero;
                System.Diagnostics.Process browserProc  = new System.Diagnostics.Process();
                browserProc.StartInfo.FileName = getDefaultBrowser();
                browserProc.StartInfo.Arguments = webBrowser1.Url.ToString();
                browserProc.StartInfo.UseShellExecute = true;
                browserProc.Start();
                
                do{
                    Thread.Sleep(100);
                    browserProc.Refresh();
                } while (browserProc.MainWindowHandle == IntPtr.Zero && !browserProc.HasExited);
                if (!browserProc.HasExited)
                {
                    hwnd = browserProc.MainWindowHandle;
                    browserProc.WaitForInputIdle();
                    MoveWindow(browserProc.MainWindowHandle, p.X, p.Y, this.Width, this.Height, true);
                    UpdateWindow(browserProc.MainWindowHandle);
                }
