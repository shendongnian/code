    public static bool IsProgramInstalled(string programDisplayName) {
        Console.WriteLine(string.Format("Checking install status of: {0}",  programDisplayName));
        foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames()) {
            object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");
            
            Console.WriteLine(programName);
            if (string.Equals(programName, programDisplayName)) {
                Console.WriteLine("Install status: INSTALLED");
                return true;
            }
        }
        Console.WriteLine("Install status: NOT INSTALLED");
        return false;
    }
