    public static IList GetFileAssociations()
    {
        return Registry.ClassesRoot.GetSubKeyNames().Where(key => key.StartsWith(".")).Select(key =>
        {
            string description = Registry.ClassesRoot.OpenSubKey(key).GetValue("") as string;
            if (!String.IsNullOrEmpty(description))
            {
                return new { key, description };
            }
            else
            {
                return null;
            }
        }).Where(a => a != null).ToList();
    }
