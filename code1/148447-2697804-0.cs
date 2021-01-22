        public static void SetAssociation(string Extension, string KeyName, string OpenWith, string FileDescription)
        {
            // The stuff that was here is basically the same
            CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.ucs", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            CurrentUser.DeleteSubKey("UserChoice", false);
            CurrentUser.Close();
        }
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
