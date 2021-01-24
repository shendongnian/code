    private void Initialize(IEnumerable fields)
    {
        List<string> fieldNames = new List<string>();
        foreach (object fld in fields)
        {
            string name = GetPropertyValue(fld, "Name").ToString();
            fieldNames.Add(name);
        }
        // Do something ...
    }
