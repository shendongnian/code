    public static string UNCPath(string path)
    {
        if (!path.StartsWith(@"\\"))
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Network" + path[0].ToString().ToUpper()))
            {
                if (key != null)
                {
                    return path = key.GetValue("RemotePath").ToString() + path.Remove(0, 2).ToString();
                }
            }
        }
        return path;
    }
