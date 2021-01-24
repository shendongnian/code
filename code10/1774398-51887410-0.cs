    public MartenDbHandler()
    {
        StoreOptions so = new StoreOptions();
        so.Connection("host=localhost;database=marten;password=root;username=postgres");
        so.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
        SetTableMeta(so);
        store = new DocumentStore(so);
    }
    private void SetTableMeta(StoreOptions storeOptions)
    {
        // We get the current assembly through the current class
        var currentAssembly = Assembly.GetExecutingAssembly();
        // we filter the defined classes according to the interfaces they implement
        var stuff = currentAssembly.DefinedTypes.Where(type => type.IsSubclassOf(typeof(MartenTableMetaDataBase))).ToList();
        foreach (Type type in stuff)
        {
            IMartenTableMetaData temp = (IMartenTableMetaData)Activator.CreateInstance(type);
            temp.SetTableMetaData(storeOptions);
        }
        OnLogEvent?.Invoke(this, $"{stuff.Count} table meta data initialized");
    }
