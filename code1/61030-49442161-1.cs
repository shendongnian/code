    using System;
    using System.Linq;
    using Microsoft.Win32;
    
    namespace Utilities
    {
        public static class NetFrameworkUtilities
        {
            public static Version GetVersion() => GetVersionHigher4() ?? GetVersionLowerOr4();
    
            private static Version GetVersionLowerOr4()
            {
                var installedVersions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                var versionNames = installedVersions?.GetSubKeyNames();
    
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                var text = versionNames?.LastOrDefault()?.Remove(0, 1);
                if (string.IsNullOrEmpty(text))
                {
                    return null;
                }
    
                return text.Contains('.')
                    ? new Version(text)
                    : new Version(Convert.ToInt32(text), 0);
            }
    
            private static Version GetVersionHigher4()
            {
                using (var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    var value = key?.GetValue("Release");
                    if (value == null)
                    {
                        return null;
                    }
    
                    // Checking the version using >= will enable forward compatibility,  
                    // however you should always compile your code on newer versions of 
                    // the framework to ensure your app works the same. 
                    var releaseKey = Convert.ToInt32(value);
                    if (releaseKey >= 461308) return new Version(4, 7, 1);
                    if (releaseKey >= 460798) return new Version(4, 7);
                    if (releaseKey >= 394747) return new Version(4, 6, 2);
                    if (releaseKey >= 394254) return new Version(4, 6, 1);
                    if (releaseKey >= 381029) return new Version(4, 6);
                    if (releaseKey >= 379893) return new Version(4, 5, 2);
                    if (releaseKey >= 378675) return new Version(4, 5, 1);
                    if (releaseKey >= 378389) return new Version(4, 5);
    
                    // This line should never execute. A non-null release key should mean 
                    // that 4.5 or later is installed. 
                    return new Version(4, 5);
                }
            }
        }
    }
