    public static string[] RefreshWindow()
    {
        Guid CLSID_ShellApplication = new Guid("13709620-C279-11CE-A49E-444553540000");
        Type shellApplicationType = Type.GetTypeFromCLSID(CLSID_ShellApplication, true);
        object shellApplication = Activator.CreateInstance(shellApplicationType);
        object windows = shellApplicationType.InvokeMember("Windows", System.Reflection.BindingFlags.InvokeMethod, null, shellApplication, new object[] { });
        Type windowsType = windows.GetType();
        var count = (int)windowsType.InvokeMember("Count", System.Reflection.BindingFlags.GetProperty, null, windows, null);
		
		string[] currentDirectories = new string[count];
        Parallel.For(0, count, i =>
        {
            object item = windowsType.InvokeMember("Item", System.Reflection.BindingFlags.InvokeMethod, null, windows, new object[] { i });
            Type itemType = item.GetType();
            string itemName = (string)itemType.InvokeMember("Name", System.Reflection.BindingFlags.GetProperty, null, item, null);
            if (itemName == "Windows Explorer" || itemName == "File Explorer")
            {
                string currDirectory = HttpUtility.HtmlEncode((string)itemType.InvokeMember("LocationURL", System.Reflection.BindingFlags.GetProperty, null, item, null)).Replace("///", @"\").Replace("/", @"\").Replace("%20", " ").Replace(@"file:\", "");
                currentDirectories[i] =  currDirectory;
            }
        });
		return currentDirectories;
    }
