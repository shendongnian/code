    WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
    bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
    if (!hasAdministrativeRight)
    {
       RunElevated(Application.ExecutablePath);
       Environment.Exit(0);
    }
    private static void RunElevated(string fileName)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.Verb = "runas";
	processInfo.FileName = fileName;
        try
        {
            Process.Start(processInfo);
        }
        catch (Win32Exception)
        {
            MessageBox.Show("Program needs administrator rights");
        }
    }
