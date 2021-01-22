    public static string UNCPath(string path)
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Network\" + path[0]))
        {
            if (key != null)
            {
                path = key.GetValue("RemotePath").ToString() + path.Remove(0, 2).ToString();
            }
        }
        return path;
    }
