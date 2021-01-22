    private void Create_abc_FileAssociation()
    {
        /***********************************/
        /**** Key1: Create ".abc" entry ****/
        /***********************************/
        Microsoft.Win32.RegistryKey key1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
        key1.CreateSubKey("Classes");
        key1 = key1.OpenSubKey("Classes", true);
        key1.CreateSubKey(".abc");
        key1 = key1.OpenSubKey(".abc", true);
        key1.SetValue("", "DemoKeyValue"); // Set default key value
        key1.Close();
        /*******************************************************/
        /**** Key2: Create "DemoKeyValue\DefaultIcon" entry ****/
        /*******************************************************/
        Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
        key2.CreateSubKey("Classes");
        key2 = key2.OpenSubKey("Classes", true);
        key2.CreateSubKey("DemoKeyValue");
        key2 = key2.OpenSubKey("DemoKeyValue", true);
        key2.CreateSubKey("DefaultIcon");
        key2 = key2.OpenSubKey("DefaultIcon", true);
        key2.SetValue("", "\"" + "(The icon path you desire)" + "\""); // Set default key value
        key2.Close();
        /**************************************************************/
        /**** Key3: Create "DemoKeyValue\shell\open\command" entry ****/
        /**************************************************************/
        Microsoft.Win32.RegistryKey key3 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
        key3.CreateSubKey("Classes");
        key3 = key3.OpenSubKey("Classes", true);
        key3.CreateSubKey("DemoKeyValue");
        key3 = key3.OpenSubKey("DemoKeyValue", true);
        key3.CreateSubKey("shell");
        key3 = key3.OpenSubKey("shell", true);
        key3.CreateSubKey("open");
        key3 = key3.OpenSubKey("open", true);
        key3.CreateSubKey("command");
        key3 = key3.OpenSubKey("command", true);
        key3.SetValue("", "\"" + "(The application path you desire)" + "\"" + " \"%1\""); // Set default key value
        key3.Close();
    }
