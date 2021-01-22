    RegistryKey rootKey = Registry.ClassesRoot.OpenSubKey(@"Access.Application\CurVer", false);
    if (rootKey == null) return false;
    string value = rootKey.GetValue("(Default)").ToString();
    int verNum = int.Parse(value.subString(value.indexOf("Access.Application.")));
    if (value.StartsWith("Access.Application.") && verNum >= 12)
    { return true; }
  
