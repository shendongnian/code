    void GetMeTheProperties(object source)
    {
        Type sourceType = source.GetType();
        
        foreach (PropertyInfo sourceProperty in sourceType.GetProperties())
        {
            int i = 1;
            Console.WriteLine("Property {0}: {1}", i, sourceProperty.Name;
        }
    }
