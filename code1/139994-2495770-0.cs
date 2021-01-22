    private void button2_Click(object sender, EventArgs e)
        {
            Point p = this.Location; 
            this.HideBrowser(); 
            IntPtr hwnd = IntPtr.Zero;
            string arguments = string.Empty;
            string browser = getDefaultBrowser(); // phisical path to default browser
            if (browser.Contains("firefox"))
                arguments = "-new-window " + webBrowser1.Url.ToString();
            if (browser.Contains("opera"))
                arguments = "-newwindow " + webBrowser1.Url.ToString();
            if (browser.Contains("iexplore"))
                arguments = "-nomerge " + webBrowser1.Url.ToString();
            if (browser.Contains("chrome"))
                arguments = "-app-launch-as-panel " + webBrowser1.Url.ToString();
                System.Diagnostics.Process browserProc  = new System.Diagnostics.Process();
                browserProc.StartInfo.FileName = browser; 
                browserProc.StartInfo.Arguments = arguments;
                browserProc.StartInfo.UseShellExecute = true; 
                browserProc.Start(); // запускаем процесс
                
                do{
                    Thread.Sleep(100);
                    browserProc.Refresh();
                } while (browserProc.MainWindowHandle == IntPtr.Zero && !browserProc.HasExited);
                if (!browserProc.HasExited)//если что-то поймали
                {
                    hwnd = browserProc.MainWindowHandle;
                    browserProc.WaitForInputIdle();
                    MoveWindow(browserProc.MainWindowHandle, p.X, p.Y, this.Width, this.Height, true);//устанавливаем новые координаты окна
                    UpdateWindow(browserProc.MainWindowHandle);
                  
                }
                                        
        }
