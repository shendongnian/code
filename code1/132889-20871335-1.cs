    public static FilterOptions Deserialize(string serializedData)
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(FilterOptions));
            var xmlReader = new XmlTextReader(serializedData,XmlNodeType.Document,null);
            var collection = (FilterOptions)xmlSerializer.Deserialize(xmlReader);
            return collection;
        }
        catch (Exception)
        {
           
            
        }
        return new FilterOptions();
    }
