    public class DA {
    public static class VersionNetFramework {
        public static string Get45or451FromRegistry()
        {//https://msdn.microsoft.com/en-us/library/hh925568(v=vs.110).aspx
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (true)
                {
                    return (@"Version: " + CheckFor45DotVersion(releaseKey));
                }
            }
        }
        // Checking the version using >= will enable forward compatibility, 
        // however you should always compile your code on newer versions of
        // the framework to ensure your app works the same.
        private static string CheckFor45DotVersion(int releaseKey)
        {//https://msdn.microsoft.com/en-us/library/hh925568(v=vs.110).aspx
            if (releaseKey >= 394271)
                return "4.6.1 installed on all other Windows OS versions or later";
            if (releaseKey >= 394254)
                return "4.6.1 installed on Windows 10 or later";
            if (releaseKey >= 393297)
                return "4.6 installed on all other Windows OS versions or later";
            if (releaseKey >= 393295)
                return "4.6 installed with Windows 10 or later";
            if (releaseKey >= 379893)
                return "4.5.2 or later";
            if (releaseKey >= 378758)
                return "4.5.1 installed on Windows 8, Windows 7 SP1, or Windows Vista SP2 or later";
            if (releaseKey >= 378675)
                return "4.5.1 installed with Windows 8.1 or later";
            if (releaseKey >= 378389)
                return "4.5 or later";
            return "No 4.5 or later version detected";
        }
        public static string GetVersionFromRegistry()
        {//https://msdn.microsoft.com/en-us/library/hh925568(v=vs.110).aspx
            string res = @"";
            // Opens the registry key for the .NET Framework entry.
            using (RegistryKey ndpKey =
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                            res += (versionKeyName + "  " + name) + Environment.NewLine;
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                res += (versionKeyName + "  " + name + "  SP" + sp) + Environment.NewLine;
                            }
                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                                res += (versionKeyName + "  " + name) + Environment.NewLine;
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    res += ("  " + subKeyName + "  " + name + "  SP" + sp) + Environment.NewLine;
                                }
                                else if (install == "1")
                                {
                                    res += ("  " + subKeyName + "  " + name) + Environment.NewLine;
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
        public static string GetUpdateHistory()
        {//https://msdn.microsoft.com/en-us/library/hh925567(v=vs.110).aspx
            string res=@"";
            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Updates"))
            {
                foreach (string baseKeyName in baseKey.GetSubKeyNames())
                {
                    if (baseKeyName.Contains(".NET Framework") || baseKeyName.StartsWith("KB") || baseKeyName.Contains(".NETFramework"))
                    {
                        using (RegistryKey updateKey = baseKey.OpenSubKey(baseKeyName))
                        {
                            string name = (string)updateKey.GetValue("PackageName", "");
                            res += baseKeyName + "  " + name + Environment.NewLine;
                            foreach (string kbKeyName in updateKey.GetSubKeyNames())
                            {
                                using (RegistryKey kbKey = updateKey.OpenSubKey(kbKeyName))
                                {
                                    name = (string)kbKey.GetValue("PackageName", "");
                                    res += ("  " + kbKeyName + "  " + name) + Environment.NewLine;
                                    if (kbKey.SubKeyCount > 0)
                                    {
                                        foreach (string sbKeyName in kbKey.GetSubKeyNames())
                                        {
                                            using (RegistryKey sbSubKey = kbKey.OpenSubKey(sbKeyName))
                                            {
                                                name = (string)sbSubKey.GetValue("PackageName", "");
                                                if (name == "")
                                                    name = (string)sbSubKey.GetValue("Description", "");
                                                res += ("    " + sbKeyName + "  " + name) + Environment.NewLine;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
    }
}
