    public enum KeyHiveSmall
    {
        ClassesRoot,
        CurrentUser,
        LocalMachine,
    }
    /// <summary>
    /// Create an associaten for a file extension in the windows registry
    /// CreateAssociation(@"vendor.application",".tmf","Tool file",@"C:\Windows\SYSWOW64\notepad.exe",@"%SystemRoot%\SYSWOW64\notepad.exe,0");
    /// </summary>
    /// <param name="ProgID">e.g. vendor.application</param>
    /// <param name="extension">e.g. .tmf</param>
    /// <param name="description">e.g. Tool file</param>
    /// <param name="application">e.g.  @"C:\Windows\SYSWOW64\notepad.exe"</param>
    /// <param name="icon">@"%SystemRoot%\SYSWOW64\notepad.exe,0"</param>
    /// <param name="hive">e.g. The user-specific settings have priority over the computer settings. KeyHive.LocalMachine  need admin rights</param>
    public static void CreateAssociation(string ProgID, string extension, string description, string application, string icon, KeyHiveSmall hive = KeyHiveSmall.CurrentUser)
    {
        RegistryKey selectedKey = null;
        switch (hive)
        {
            case KeyHiveSmall.ClassesRoot:
                Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(extension).SetValue("", ProgID);
                selectedKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(ProgID);
                break;
            case KeyHiveSmall.CurrentUser:
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Classes\" + extension).SetValue("", ProgID);
                selectedKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Classes\" + ProgID);
                break;
            case KeyHiveSmall.LocalMachine:
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Classes\" + extension).SetValue("", ProgID);
                selectedKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Classes\" + ProgID);
                break;
        }
        if (selectedKey != null)
        {
            if (description != null)
            {
                selectedKey.SetValue("", description);
            }
            if (icon != null)
            {
                selectedKey.CreateSubKey("DefaultIcon").SetValue("", icon, RegistryValueKind.ExpandString);
                selectedKey.CreateSubKey(@"Shell\Open").SetValue("icon", icon, RegistryValueKind.ExpandString);
            }
            if (application != null)
            {
                selectedKey.CreateSubKey(@"Shell\Open\command").SetValue("", "\"" + application + "\"" + " \"%1\"", RegistryValueKind.ExpandString);
            }
        }
        selectedKey.Flush();
        selectedKey.Close();
    }
     /// <summary>
        /// Creates a association for current running executable
        /// </summary>
        /// <param name="extension">e.g. .tmf</param>
        /// <param name="hive">e.g. KeyHive.LocalMachine need admin rights</param>
        /// <param name="description">e.g. Tool file. Displayed in explorer</param>
        public static void SelfCreateAssociation(string extension, KeyHiveSmall hive = KeyHiveSmall.CurrentUser, string description = "")
        {
            string ProgID = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.FullName;
            string FileLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            CreateAssociation(ProgID, extension, description, FileLocation, FileLocation + ",0", hive);
        }
