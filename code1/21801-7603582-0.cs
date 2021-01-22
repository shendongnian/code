        public static bool is64bit(String host)
        {
            using (var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, host))
            using (var key = reg.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\"))
            {
                return key.GetValue("ProgramFilesDir (x86)") !=null;
            }
        }
