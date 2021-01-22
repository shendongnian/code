    string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
    foreach (char c in Path.GetInvalidFileNameChars())
    {
        illegal = illegal.Replace(c.ToString(), ""); 
    }
    foreach (char c in Path.GetInvalidPathChars())
    {
        illegal = illegal.Replace(c.ToString(), ""); 
    }
