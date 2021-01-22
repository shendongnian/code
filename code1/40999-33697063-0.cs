    void Main()
    {
	    YourTable.OrderBy(v => Random()).FirstOrDefault.Dump();
    }
    [Function(Name = "NEWID", IsComposable = true)]
    public Guid Random()
    {
	    throw new NotImplementedException();
    }
