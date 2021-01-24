    public static object Deserialize(Stream data)
    {
        AbstractTest test = Serializer.Deserialize<AbstractTest>(data);
        
        return test;
    }
