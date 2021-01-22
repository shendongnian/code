    /// <summary>
    /// Returns true if a filename's extension is .001.
    /// If the extensions is .rar, check to see if there is a part number
    /// immediately before the extension.
    /// If there is no part number, return true.
    /// If there is a part number, returns true if the part number is 1.
    /// In all other cases, return false.
    /// </summary>
    static bool isMainFile(string name)
    {
        string extension = Path.GetExtension(name);
        if (extension == ".001")
            return true;
        if (extension != ".rar")
            return false;
        Match match = Regex.Match(name, @"\.part(\d+)\.rar$");
        if (!match.Success)
            return true;
        string partNumber = match.Groups[1].Value.TrimStart('0');
        return partNumber == "1";
    }
