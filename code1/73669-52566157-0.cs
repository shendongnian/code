    //use a Property or Field for keeping the info to avoid runtime computation
    public static bool NotInDesignMode { get; } = IsNotInDesignMode();
    private static bool IsNotInDesignMode()
    {
        /*
        File.WriteAllLines(@"D:\1.log", new[]
        {
            LicenseManager.UsageMode.ToString(), //not always reliable, e.g. WPF app in Blend this will return RunTime
            Process.GetCurrentProcess().ProcessName, //filename without extension
            Process.GetCurrentProcess().MainModule.FileName, //full path
            Process.GetCurrentProcess().MainModule.ModuleName, //filename
            Assembly.GetEntryAssembly()?.Location, //null for WinForms app in VS IDE
            Assembly.GetEntryAssembly()?.ToString(), //null for WinForms app in VS IDE
            Assembly.GetExecutingAssembly().Location, //always return your project's output assembly info
            Assembly.GetExecutingAssembly().ToString(), //always return your project's output assembly info
        });
        //*/
        //LicenseManager.UsageMode will return RunTime if LicenseManager.context is not present.
        //So you can not return true by judging it's value is RunTime.
        if (LicenseUsageMode.Designtime == LicenseManager.UsageMode) return false;
        var procName = Process.GetCurrentProcess().ProcessName.ToLower();
        return "devenv" != procName //WinForms app in VS IDE
            && "xdesproc" != procName //WPF app in VS IDE/Blend
            && "blend" != procName //WinForms app in Blend
            //other IDE's process name if you detected by log from above
            ;
    }
