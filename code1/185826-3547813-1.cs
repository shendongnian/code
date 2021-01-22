    private string[] myProperty;
    public Indexer<string> MyProperty
    {
        get
        {
            return myProperty.GetIndexer();
        }
    }
