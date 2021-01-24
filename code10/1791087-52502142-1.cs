    static void Main(string[] args)
    {
        ConversionMeta[] conversionMetaArray = new ConversionMeta[3];
        conversionMetaArray[0] = new ConversionMeta()
        {
            Id = "deleted",
            Name = "delete page from PDF",
            Description = "You can delete any page from PDF blah blah..."
        };
        conversionMetaArray[1] = new ConversionMeta()
        {
            Id = "deleted",
            Name = "delete page from PDF",
            Description = "You can delete any page from PDF blah blah..."
        };
        conversionMetaArray[2] = new ConversionMeta()
        {
            Id = "deleted",
            Name = "delete page from PDF",
            Description = "You can delete any page from PDF blah blah..."
        };
        string json = JsonConvert.SerializeObject(conversionMetaArray);
    }
    
