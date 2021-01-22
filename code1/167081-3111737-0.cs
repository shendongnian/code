    private string GetMimeType (string fileName)
    {
    	string mimeType = "application/unknown";
    	string ext = System.IO.Path.GetExtension(fileName).ToLower();
    	Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
    	if (regKey != null && regKey.GetValue("Content Type") != null)
    	mimeType = regKey.GetValue("Content Type").ToString();
    	return mimeType;
    }
