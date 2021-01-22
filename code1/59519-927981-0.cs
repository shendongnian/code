    RegistryKey screenSaverKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
    if (screenSaverKey != null)
    {
        string screenSaverFilePath = screenSaverKey.GetValue("SCRNSAVE.EXE", string.Empty).ToString();
        if (!string.IsNullOrEmpty(screenSaverFilePath) && File.Exists(screenSaverFilePath))
        {
            Process screenSaverProcess = Process.Start(new ProcessStartInfo(screenSaverFilePath, "/s"));  // "/s" for full-screen mode
            screenSaverProcess.WaitForExit();  // Wait for the screensaver to be dismissed by the user
        }
    }
