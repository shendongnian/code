    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    public void MyMethod(InternetExplorer driver)
    {
            //.....
            while (currentPos++ <= nPosition)
            {
                SetForegroundWindow((IntPtr)driver.HWND);
                System.Windows.Forms.SendKeys.SendWait(Down_Key);
                Task.Delay(100).Wait();
            }
            SetForegroundWindow((IntPtr)driver.HWND);
            System.Windows.Forms.SendKeys.SendWait(Enter_Key);
            SetForegroundWindow((IntPtr)driver.HWND);
            System.Windows.Forms.SendKeys.Flush();
    }
