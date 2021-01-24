    var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
    
    using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
    {
       Key.SetValue(appName, 99999, RegistryValueKind.DWord);
    }
