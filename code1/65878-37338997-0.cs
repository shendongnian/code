    private string GetMimeType(string sFileName)
    {
      // Get file extension and if it is empty, return unknown
      string sExt = Path.GetExtension(sFileName);
      if (string.IsNullOrEmpty(sExt)) return "Unknown file type";
      // Default type is "EXT File"
      string mimeType = string.Format("{0} File", sExt.ToUpper().Replace(".", ""));
      // Open the registry key for the extension under HKEY_CLASSES_ROOT and return default if it doesn't exist
      Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(sExt);
      if (regKey == null) return mimeType;
      // Get the "(Default)" value and re-open the key for that value
      string sSubType = regKey.GetValue("").ToString();
      regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(sSubType);
      // If it exists, get the "(Default)" value of the new key
      if (regKey?.GetValue("") != null) mimeType = regKey.GetValue("").ToString();
      
      // Return the value
      return mimeType;
    }
