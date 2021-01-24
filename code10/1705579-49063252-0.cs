    void SetParameter(string name, ref string parameter)
    {
        if (line.Contains(name))
        {
           parameter = line.Replace(name, string.Empty).Trim();                        
        }
    }
    SetParameter("[myValue]", ref myParameter);
