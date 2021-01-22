    public static string GetUniqueKey(int length)
    {
        string guidResult = string.Empty;
        
        while (guidResult.Length < length)
        {
            // Get the GUID.
            guidResult += Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }
    
        // Make sure length is valid.
        if (length <= 0 || length > guidResult.Length)
            throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
    
        // Return the first length bytes.
        return guidResult.Substring(0, length);
    }
