    public static bool GroupExists(SPGroupCollection groups, string name)
    {
        if (string.IsNullOrEmpty(name) || (name.Length > 255) || (groups == null) || (groups.Count == 0))
        {
            return false;
        }
        else
        {
            return (groups.GetCollection(new String[] { name }).Count > 0);
        }
    }
