    public string ResolveName(string name)
    {
       var tmpDisplay = Regex.Replace(name, "([^A-Z ])([A-Z])", "$1 $2");
       return Regex.Replace(tmpDisplay, "([A-Z]+)([A-Z][^A-Z$])", "$1 $2").Trim();
    }
