    void SetParameter(string line, string name, ref string parameter)
    {
        if (line.Contains(name))
        {
           parameter = line.Replace(name, string.Empty).Trim();                        
        }
    }
    SetParameter(line, "[myValue]", ref myParameter);
