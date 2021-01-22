        public static void SetAssociation(string Extension, string KeyName, string OpenWith, string FileDescription)
        {
            // The stuff that was above here is basically the same
            // Delete the key instead of trying to change it
            CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.ucs", true);
            CurrentUser.DeleteSubKey("UserChoice", false);
            CurrentUser.Close();
            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
