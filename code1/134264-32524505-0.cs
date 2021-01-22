    using System.Diagnostics;
    
    
    namespace PlatformInfo
    {
    
        public delegate int BrowserRatingCallback_t(string packageName);
    
    
        public class BrowserInfo : System.IComparable<BrowserInfo>
        {
            public string Name;
            public string Path;
            public int Preference;
    
    
            public int CompareTo(BrowserInfo other)
            {
                if (this == null || other == null)
                    return 0;
    
                int pref = this.Preference.CompareTo(other.Preference);
    
                if (pref != 0)
                    return pref;
    
                return string.Compare(this.Name, other.Name, true);
            } // End Function CompareTo 
    
    
            public static int DefaultBrowserRating(string packageName)
            {
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Google")) return 1;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Chromium")) return 2;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Opera")) return 3;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Firefox")) return 4;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Midori")) return 5;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Safari")) return 9000;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Edge")) return 9998;
                if (EmbeddedWebServer.StringHelpers.Contains(packageName, "Explorer")) return 9999;
    
                return 9997;
            }
    
    
            public static System.Collections.Generic.List<BrowserInfo> GetPreferableBrowser()
            {
                return GetPreferableBrowser(BrowserInfo.DefaultBrowserRating);
            }
    
    
            public static System.Collections.Generic.List<BrowserInfo> GetPreferableBrowser(BrowserRatingCallback_t browserRatingCallback)
            {
                if (System.Environment.OSVersion.Platform != System.PlatformID.Unix)
                    return Win.GetPreferableBrowser(browserRatingCallback);
                // ELSE: Linux / Unix / MacOS
    
                if (DistroInfo.PackageManager == DistroInfo.PackageManager_t.dpkg)
                    return dpkg.GetInstalledBrowsers(browserRatingCallback);
    
                return new System.Collections.Generic.List<BrowserInfo>();
            }
    
    
        } // End Class BrowserInfo : System.IComparable<BrowserInfo> 
    
    
    
        public class DistroInfo
        {
    
            public enum Distro_t : int
            {
                 Debian 
                ,Ubuntu 
                ,Mint 
    
                ,Arch
                ,Gentoo
    
                ,CentOS
                ,Fedora
                ,RedHat 
                 
                 
                ,Mageia
                ,Suse 
    
                ,Mandrake 
                ,YellowDog 
    
                ,Slackware 
                
                ,SunJDS
                ,Solaris 
                ,UnitedLinux
                 
    
                ,Unknown
            } // End Enum Distro_t 
    
    
            public enum PackageManager_t : int
            { 
                 dpkg
                ,rpm
                ,portage
                ,pacman
                ,pkgtool
                ,ips
                ,unknown
            } // End Enum PackageManager_t 
    
    
            public enum DistroFamily_t : int
            {
                Debian, RedHat, Unknown 
            } // End Enum DistroFamily_t
    
    
            public static DistroFamily_t DistroFamily
            {
                get {
    
                    if (Distro == Distro_t.Ubuntu)
                        return DistroFamily_t.Debian;
    
                    if (Distro == Distro_t.Debian)
                        return DistroFamily_t.Debian;
    
                    if (Distro == Distro_t.Mint)
                        return DistroFamily_t.Debian;
    
    
                    if (Distro == Distro_t.RedHat)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.CentOS)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.Fedora)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.Suse)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.Mageia)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.Mandrake)
                        return DistroFamily_t.RedHat;
    
                    if (Distro == Distro_t.YellowDog)
                        return DistroFamily_t.RedHat;
    
    
                    return DistroFamily_t.Unknown;
                }
            } // End Property DistroFamily
    
    
            public static PackageManager_t PackageManager
            {
                get {
                    if (DistroFamily == DistroFamily_t.Debian)
                        return PackageManager_t.dpkg;
    
                    if (DistroFamily == DistroFamily_t.RedHat)
                        return PackageManager_t.rpm;
    
                    if(Distro == Distro_t.Arch)
                        return PackageManager_t.pacman;
    
                    if(Distro == Distro_t.Gentoo)
                        return PackageManager_t.portage;
    
                    if(Distro == Distro_t.Slackware)
                        return PackageManager_t.pkgtool;
    
    
                    if(Distro == Distro_t.Solaris)
                        return PackageManager_t.ips;
    
                    if(Distro == Distro_t.SunJDS)
                        return PackageManager_t.ips;
    
                    return PackageManager_t.unknown;
                }
            } // End Property PackageManager
    
    
            // Release Files in /etc (from Unix.com)
            // Novell SuSE---> /etc/SuSE-release
            // Red Hat--->/etc/redhat-release, /etc/redhat_version
            // Fedora-->/etc/fedora-release
            // Slackware--->/etc/slackware-release, /etc/slackware-version
            // Old Debian--->/etc/debian_release, /etc/debian_version
            // New Debian--->/etc/os-release
            // Mandrake--->/etc/mandrake-release
            // Yellow dog-->/etc/yellowdog-release
            // Sun JDS--->/etc/sun-release
            // Solaris/Sparc--->/etc/release
            // Gentoo--->/etc/gentoo-release
    
            // cat /etc/issue
            // CentOS Linux release 6.0 (Final)
            // Kernel \r on an \m
    
            // cat /proc/version
            // uname -a
            // If you are in a container, beware cat /proc/version will give the host distro, not the container one.
    
            // http://unix.stackexchange.com/questions/35183/how-do-i-identify-which-linux-distro-is-running
            public static Distro_t Distro
            {
                get{
                    string issue = null;
    
                    if (System.IO.File.Exists("/etc/issue"))
                        issue = System.IO.File.ReadAllText("/etc/issue", System.Text.Encoding.UTF8);
    
                    if (EmbeddedWebServer.StringHelpers.Contains(issue, "Ubuntu"))
                        return Distro_t.Ubuntu;
    
                    if (System.IO.File.Exists("/etc/os-release"))
                        return Distro_t.Debian; // New Debian
    
                    if (System.IO.File.Exists("/etc/debian_release"))
                        return Distro_t.Debian; // Old Debian
    
    
    
    
                    if (System.IO.File.Exists("/etc/gentoo-release"))
                        return Distro_t.Gentoo; // Not yet supported
    
                    if (System.IO.File.Exists("/etc/SuSE-release"))
                        return Distro_t.Suse;
    
    
    
                    if (EmbeddedWebServer.StringHelpers.Contains(issue, "CentOS"))
                        return Distro_t.CentOS;
    
                    if (System.IO.File.Exists("/etc/fedora-release"))
                        return Distro_t.Fedora;
    
                    if (System.IO.File.Exists("/etc/redhat_version"))
                        return Distro_t.Fedora;
    
                
    
                    // Unsupported 
                    if (System.IO.File.Exists("/etc/mandrake-release"))
                        return Distro_t.Mandrake;
                
                    if (System.IO.File.Exists("/etc/slackware-release"))
                        return Distro_t.Slackware;
    
                    if (System.IO.File.Exists("/etc/yellowdog-release"))
                        return Distro_t.YellowDog;
    
                    if (System.IO.File.Exists("/etc/yellowdog-release"))
                        return Distro_t.YellowDog;
    
                    if (System.IO.File.Exists("/etc/sun-release"))
                        return Distro_t.SunJDS;
    
                    if (System.IO.File.Exists("/etc/release"))
                        return Distro_t.Solaris;
    
                    if (System.IO.File.Exists("/etc/UnitedLinux-release"))
                        return Distro_t.Solaris;
                    
                    return Distro_t.Unknown;
                } // End Get 
            } // End Property Distro
    
    
        } // End Class DistroInfo 
    
    
    
        public class dpkg
        {
    
    
            public static bool HasDPKG()
            {
                // if (System.IO.File.Exists("/usr/bin/dpkg")) return true;
                if (DistroInfo.PackageManager == DistroInfo.PackageManager_t.dpkg)
                    return true;
    
                return false;
            } // End Function HasDPKG
    
    
            public static bool IsPackageInstalled(string packageName)
            {
                Process process = new Process();
                process.StartInfo.FileName = "dpkg";
                process.StartInfo.Arguments = "-s \"" + packageName + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                process.WaitForExit();
                int result = process.ExitCode;
    
                if (result == 0)
                    return true;
    
                return false;
            } // End Function IsPackageInstalled
    
    
            public static string GetExecutable(string packageName)
            {
                Process process = new Process();
                process.StartInfo.FileName = "dpkg";
                process.StartInfo.Arguments = "-L \"" + packageName + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                //* Read the output (or the error)
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
    
                if (output != null)
                    output = output.Replace("\r", "\n");
                string[] lines = output.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
    
                string executable = null;
    
                foreach (string line in lines)
                {
                    if (line.IndexOf("/bin/") != -1)
                    {
                        executable = line;
                        break;
                    }
                }
    
                return executable;
            } // End Function GetExecutable
    
    
            public static System.Collections.Generic.List<BrowserInfo> GetInstalledBrowsers()
            {
                return GetInstalledBrowsers(BrowserInfo.DefaultBrowserRating);
            } // End Function GetInstalledBrowsers
    
    
            public static System.Collections.Generic.List<BrowserInfo> GetInstalledBrowsers(BrowserRatingCallback_t browserRatingCallback )
            {
    
                System.Collections.Generic.List<BrowserInfo> ls = new System.Collections.Generic.List<BrowserInfo>();
                System.Collections.Generic.List<string> packageList = GetPossibleBrowsers();
    
                foreach (string packageName in packageList)
                {
                    if (IsPackageInstalled(packageName))
                    {
                        int sort = browserRatingCallback(packageName);
    
                        ls.Add(new BrowserInfo()
                        {
                             Name = packageName
                            ,Path = GetExecutable(packageName)
                            ,Preference = sort
                        });
    
                    } // End if (isPackageInstalled(packageName)) 
    
                } // Next packageName 
    
                ls.Sort();
    
                return ls;
            } // End Function GetInstalledBrowsers
    
    
            public static System.Collections.Generic.List<string> GetPossibleBrowsers()
            {
                return SearchPackages("www-browser");
            } // End Function GetPossibleBrowsers 
    
    
            public static System.Collections.Generic.List<string> SearchPackages(string categoryName)
            {
                System.Collections.Generic.List<string> ls = new System.Collections.Generic.List<string>();
    
                Process process = new Process();  // e.g. apt-cache search www-browser 
                process.StartInfo.FileName = "apt-cache";
                process.StartInfo.Arguments = "search \"" + categoryName + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                //* Read the output (or the error)
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
    
                if (output != null)
                    output = output.Replace("\r", "\n");
    
                string[] lines = output.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
    
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
    
                    int pos = line.IndexOf(" ");
                    if (pos < 0)
                        continue;
    
                    string packageName = line.Substring(0, pos);
                    ls.Add(packageName);
                } // Next line 
    
                return ls;
            } // End Function SearchPackages 
    
    
        } // End Class dpkg 
    
        public class Win
        {
    
            public static System.Collections.Generic.List<BrowserInfo> GetPreferableBrowser(BrowserRatingCallback_t browserRatingCallback)
            {
                System.Collections.Generic.List<BrowserInfo> ls = new System.Collections.Generic.List<BrowserInfo>();
                if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                    return ls;
    
                using (Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine)
                {
                    Microsoft.Win32.RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                    if (webClientsRootKey != null)
                        foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                            if (webClientsRootKey.OpenSubKey(subKeyName) != null)
                                if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
                                    if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
                                        if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
                                        {
                                            string commandLineUri = (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
                                            if (string.IsNullOrEmpty(commandLineUri))
                                                continue;
                                            commandLineUri = commandLineUri.Trim("\"".ToCharArray());
    
                                            // viewer.Executable = commandLineUri;
                                            string Name = (string)webClientsRootKey.OpenSubKey(subKeyName).GetValue(null);
    
                                            ls.Add(new BrowserInfo()
                                            {
                                                Name = Name
                                                ,
                                                Path = commandLineUri
                                                ,
                                                Preference = browserRatingCallback(Name)
                                            });
    
                                        }
                } // End Using 
    
    
                using (Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser)
                {
                    Microsoft.Win32.RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                    if (webClientsRootKey != null)
                        foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                            if (webClientsRootKey.OpenSubKey(subKeyName) != null)
                                if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
                                    if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
                                        if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
                                        {
                                            string commandLineUri = (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
                                            if (string.IsNullOrEmpty(commandLineUri))
                                                continue;
                                            commandLineUri = commandLineUri.Trim("\"".ToCharArray());
    
                                            // viewer.Executable = commandLineUri;
                                            string Name = (string)webClientsRootKey.OpenSubKey(subKeyName).GetValue(null);
    
                                            ls.Add(new BrowserInfo()
                                            {
                                                Name = Name
                                                ,
                                                Path = commandLineUri
                                                ,
                                                Preference = browserRatingCallback(Name)
                                            });
    
                                        }
                } // End Using
    
                ls.Sort();
                return ls;
            } // End Function GetPreferableBrowser 
    
    
        }
    
    
        public class rpm
        {
    
    
            public rpm()
            {
                throw new System.NotImplementedException("TODO");
            }
    
    
            // # rpm -q --whatprovides webclient
            //links-graphic-2.1-0.pre11.1mdk
            //lynx-2.8.5-1mdk
            //links-2.1-0.pre13.3mdk
            //kdebase-common-3.2.3-134.8.101mdk
            //mozilla-1.7.2-12.2.101mdk
            //epiphany-1.2.8-4.2.101mdk
            //wget-1.9.1-4.2.101mdk
    
            // Another rough method is apropos
            // This lists unexpected results too, and misses firefox as well as konqueror, who didn't filled the man-pages correctly. 
            //snx]->~ > apropos browser
            //alevt (1)            - X11 Teletext browser
            //amrecover (8)        - Amanda index database browser
            //elinks (1)           - lynx-like alternative character mode WWW browser
            //gnome-moz-remote (1) - remote control of browsers.
            //goad-browser (1)     - Graphical GOAD browser
            //links (1)            - lynx-like alternative character mode WWW browser
            //LinNeighborhood (1)  - an SMB Network Browser
            //lynx (1)             - a general purpose distributed information browser for the World Wide Web
            //mozilla-1.5 (1)      - a Web browser for X11 derived from Netscape Communicator
            //opera (1)            - a graphical web browser
            //sensible-browser (1) - sensible editing, paging, and web browsing
            //smbtree (1)          - A text based smb network browser
            //www (1)              - the W3C Line Mode Browser.
            //www-browser (1)      - a general purpose distributed information browser for the World Wide Web
            //xfhelp (1)           - lauches an HTML browser to display online documentation for
            //                       "The Cholesterol Free Desktop Environment"
            //viewres (1x)         - graphical class browser for Xt
            //htsserver (1)        - offline browser server : copy websites to a local directory
            //httrack (1)          - offline browser : copy websites to a local directory
            //webhttrack (1)       - offline browser : copy websites to a local directory
        } // End Class RPM 
    
    
    } // End Namespace 
