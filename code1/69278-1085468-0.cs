        RegistryKey regVersionString = Registry.ClassesRoot.OpenSubKey("Visio.Drawing\\CurVer");
        Console.WriteLine("VERSION: " + regVersionString.GetValue(""));
        RegistryKey regClassId = Registry.ClassesRoot.OpenSubKey(regVersionString.GetValue("") + "\\CLSID");
        Console.WriteLine("CLSID: " + regClassId.GetValue(""));
        RegistryKey regInstallPath = Registry.ClassesRoot.OpenSubKey("CLSID\\" + regClassId.GetValue("") + "\\LocalServer32");
        Console.WriteLine("PATH: " + regInstallPath.GetValue(""));
