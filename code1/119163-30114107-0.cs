        public class InstalledProgramInfo
        {
            public string name;
            public string path;
        }
            public static InstalledProgramInfo FindInstalledApp(string findname, bool dump = false)
        {
            if (String.IsNullOrEmpty(findname)) return null;
            
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryHive[] keys = new RegistryHive[] { RegistryHive.CurrentUser, RegistryHive.LocalMachine };
            RegistryView[] views = new RegistryView[] { RegistryView.Registry32, RegistryView.Registry64 };
            foreach (var hive in keys)
            {
                foreach (var view in views)
                {
                    RegistryKey rk = null, 
                        basekey = null;
                    try
                    {
                        basekey = RegistryKey.OpenBaseKey(hive, view);
                        rk = basekey.OpenSubKey(uninstallKey);
                    }
                    catch (Exception ex) { continue; }
                    if (basekey == null || rk == null) 
                        continue;
                    if (rk == null)
                    {
                        if (dump) Console.WriteLine("ERROR: failed to open subkey '{0}'", uninstallKey);
                        return null;
                    }
                    if (dump) Console.WriteLine("Reading registry at {0}", rk.ToString());
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        try
                        {
                            RegistryKey sk = rk.OpenSubKey(skName);
                            if (sk == null) continue;
                            object skname = sk.GetValue("DisplayName");
                            
                            object skpath = sk.GetValue("InstallLocation");
                            if (skpath == null)
                            {
                                skpath = sk.GetValue("UninstallString");
                                if (skpath == null) continue;
                                FileInfo fi = new FileInfo(skpath.ToString());
                                skpath = fi.Directory.FullName;
                            }
                            if (skname == null || skpath == null) continue;
                            string thisname = skname.ToString();
                            string thispath = skpath.ToString();
                            if (dump) Console.WriteLine("{0}: {1}", thisname, thispath);
                            if (!thisname.Equals(findname, StringComparison.CurrentCultureIgnoreCase))
                                continue;
                            InstalledProgramInfo inf = new InstalledProgramInfo();
                            inf.name = thisname;
                            inf.path = thispath;
                            return inf;
                        }
                        catch (Exception ex)
                        {
                            // todo
                        }
                    }                   
                } // view
            } // hive
            return null;
        }
