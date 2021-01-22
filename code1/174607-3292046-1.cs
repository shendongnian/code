    public void EquivalentSplit(string path, out string head, out string tail)
    {
    
        // Get the directory separation character (i.e. '\').
        string separator = System.IO.Path.DirectorySeparatorChar.ToString();
    
        // Trim any separators at the end of the path
        string lastCharacter = path.Substring(path.Length - 1);
        if (separator == lastCharacter)
        {
            path = path.Substring(0, path.Length - 1);
        }
    
        int lastSeparatorIndex = path.LastIndexOf(separator);
    
        head = path.Substring(0, lastSeparatorIndex);
        tail = path.Substring(lastSeparatorIndex + separator.Length,
            path.Length - lastSeparatorIndex - separator.Length);
    
    }
