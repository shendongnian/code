    void SetParameter(string line, string name, ref string parameter)
    {
        var replaced = line.Replace(name, string.Empty);
        if (line != replaced)
        {
           parameter = replaced.Trim();                        
        }
    }
