    public static string GetPropertyValue(this Principal principal, string property)
    {
        var directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
        if (directoryEntry != null && directoryEntry.Properties.Contains(property))
        {
            return directoryEntry.Properties[property].Value.ToString();
        }
    
        return null;
    }
