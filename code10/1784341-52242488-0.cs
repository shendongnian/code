    private static readonly string BrowserEmulationRegistryKeyPath =
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
    			
            /// <summary>
    		/// Add the process name to internet explorer emulation key
    >     	/// i do this because the default IE wrapper dose not support the latest JS features
    >     	/// Add process to emulation key and set a DWord value (11001) for it means we want use IE.11 as WebBrowser component
            /// </summary>
            public bool EmulateInternetExplorer()
            {
                using (
                    var browserEmulationKey = Registry.CurrentUser.OpenSubKey(BrowserEmulationRegistryKeyPath,
                        true))
                {
                    if (browserEmulationKey == null)
                        Registry.CurrentUser.CreateSubKey(BrowserEmulationRegistryKeyPath);
    
    
                    string processName = $"{Process.GetCurrentProcess().ProcessName}.exe";
    
                    // Means emulation already added and we are ready to start
                    if (browserEmulationKey?.GetValue(processName) != null)
                        return true;
    
                    // Emulation key not exists and we must add it ( We return false because application restart to take effect of changes )
                    if (browserEmulationKey != null)
                    {
                        browserEmulationKey.SetValue(processName, 11001, RegistryValueKind.DWord);
                        browserEmulationKey.Flush();
                    }
                    return false;
                }
            }
