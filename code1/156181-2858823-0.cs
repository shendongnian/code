    string path = @"c:\dev";
    string searchPattern = "*.*";
    string[] dirNameArray = Directory.GetDirectories(path, searchPattern, SearchOption.AllDirectories);
    // Or, for better performance:
    // (but breaks if you don't have access to a sub directory; see 2nd link below)
    IEnumerable<string> dirNameEnumeration = Directory.EnumerateDirectories(path, searchPattern, SearchOption.AllDirectories);
