    internal static bool TryOpenUrl(string p_url)
        {
            // try use default browser [registry: HKEY_CURRENT_USER\Software\Classes\http\shell\open\command]
            try
            {
                string keyValue = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\http\shell\open\command", "", null) as string;
                if (string.IsNullOrEmpty(keyValue) == false)
                {
                    string browserPath = keyValue.Replace("%1", p_url);
                    System.Diagnostics.Process.Start(browserPath);
                    return true;
                }
            }
            catch { }
            // try open browser as default command
            try
            {
                System.Diagnostics.Process.Start(p_url); //browserPath, argUrl);
                return true;
            }
            catch { }
            // try open through 'explorer.exe'
            try
            {
                string browserPath = GetWindowsPath("explorer.exe");
                string argUrl = "\"" + p_url + "\"";
                System.Diagnostics.Process.Start(browserPath, argUrl);
                return true;
            }
            catch { }
            // return false, all failed
            return false;
        }
