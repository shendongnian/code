    public static Icon IconFromExtension(string extension,
                                                SystemIconSize size)
        {
            // Add the '.' to the extension if needed
            if (extension[0] != '.') extension = '.' + extension;
            //opens the registry for the wanted key.
            RegistryKey Root = Registry.ClassesRoot;
            RegistryKey ExtensionKey = Root.OpenSubKey(extension);
            ExtensionKey.GetValueNames();
            RegistryKey ApplicationKey =
                Root.OpenSubKey(ExtensionKey.GetValue("").ToString());
            RegistryKey CurrentVer = null;
            try
            {
                CurrentVer = Root.OpenSubKey(ApplicationKey.OpenSubKey("CurVer").GetValue("").ToString());
            }
            catch (Exception ex)
            {
                //current version not found... carry on without it?
            }
            if (CurrentVer != null)
                ApplicationKey = CurrentVer;
            //gets the name of the file that have the icon.
            string IconLocation =
                ApplicationKey.OpenSubKey("DefaultIcon").GetValue("").ToString();
            string[] IconPath = IconLocation.Split(',');
            IntPtr[] Large = null;
            IntPtr[] Small = null;
            int iIconPathNumber = 0;
            if (IconPath.Length > 1)
                iIconPathNumber = 1;
            else
                iIconPathNumber = 0;
            if (IconPath[iIconPathNumber] == null) IconPath[iIconPathNumber] = "0";
            Large = new IntPtr[1];
            Small = new IntPtr[1];
            //extracts the icon from the file.
            if (iIconPathNumber > 0)
            {
                ExtractIconEx(IconPath[0],
                    Convert.ToInt16(IconPath[iIconPathNumber]), Large, Small, 1);
            }
            else
            {
                ExtractIconEx(IconPath[0],
                    Convert.ToInt16(0), Large, Small, 1);
            }
            return size == SystemIconSize.Large ?
                Icon.FromHandle(Large[0]) : Icon.FromHandle(Small[0]);
        }
