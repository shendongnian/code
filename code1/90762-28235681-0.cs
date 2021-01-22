    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    public static bool BringToFrontCustom(Form f)
    {
        bool toReturn = true;
        try
        {
            //This is the same as the name of the executable without the .exe at the end            
            Process[] processes = Process.GetProcessesByName("MyFormName");
            
            SetForegroundWindow(processes[0].MainWindowHandle);
            f.BringToFront();
        }
        catch(Exception e)
        {
             toReturn = false;
             MessageBox.Show("Something went wrong, Please bring the window to front manually");
        }
        return toReturn;
    }
