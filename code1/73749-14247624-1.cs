    public List<string> OperationModes
    {
        get
        {
           return Enum.GetNames(typeof(SomeENUM)).ToList();
        }
    }
