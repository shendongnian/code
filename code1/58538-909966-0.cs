    private const string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
    private string GetPathForExe(string fileName)
    {
        RegistryKey localMachine = Registry.LocalMachine;
        RegistryKey fileKey = localMachine.OpenSubKey(string.Format(@"{0}\{1}", keyBase, fileName));
        object result = null;
        if (fileKey != null)
        {
            result = fileKey.GetValue(string.Empty);
        }
        fileKey.Close();
    
        return (string)result;
    }
