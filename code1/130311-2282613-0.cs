    WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
        if (!hasAdministrativeRight)
        {
            RunElevated(Application.ExecutablePath);
            this.Close();
            Application.Exit();
        }
    private static void RunElevated(string fileName)
    {
        //MessageBox.Show("Run: " + fileName);
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.Verb = "runas";
        processInfo.FileName = fileName;
        try
        {
            Process.Start(processInfo);
        }
        catch (Win32Exception)
        {
            //Do nothing. Probably the user canceled the UAC window
        }
    }
