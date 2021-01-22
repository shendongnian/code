    public SomeClassInit(Guid docId, DateTime addedOn)
    {
        SomeClassInitCore(docId, addedOn);
    }
    
    public SomeClassInit(Guid docId)
    {
        SomeClassInitCore(docId, null);
    }
    
    private SomeClassInitCore(Guid docId, DateTime? addedOn)
    {
        // set default value
        if (addedOn.IsNull) addedOn = DateTime.Now;
    
        //Init codes here
    }
