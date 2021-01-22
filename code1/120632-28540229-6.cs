    public static string UNCPath(string path)
    {
        if (!path.StartsWith(@"\\"))
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Network\\" + path[0]))
            {
                if (key != null)
                {
                    return key.GetValue("RemotePath").ToString() + path.Remove(0, 2).ToString();
                }
            }
        }
        return path;
    }
