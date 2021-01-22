       public static void RemoveControlPanelProgram(string apllicationName)
        {
           string InstallerRegLoc = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
           RegistryKey homeKey = (Registry.LocalMachine).OpenSubKey(InstallerRegLoc, true);
           RegistryKey appSubKey = homeKey.OpenSubKey(apllicationName);
           if (null != appSubKey)
           {
             homeKey.DeleteSubKey(apllicationName);
           }
         }
