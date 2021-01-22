    private IObjectFactory ObjectFactory { get; set; }
    public ExcelImporter(IObjectFactory objectFactory)
    {
        ObjectFactory = objectFactory;
    }
    public ITable Import()
    {
        var result = ObjectFactory.Get<ITable>();
        { Do import here }
        return result;
    }
}
