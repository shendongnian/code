    public static Foo Create(int id, string property, string value)
    {
        Foo ret = new Foo
        {
            Id = id
        };
        foreach (FieldInfo element in typeof(Foo).GetFields())
            if (element.Name == property)
                element.SetValue(ret, value);
        foreach (PropertyInfo element in typeof(Foo).GetProperties())
            if (element.Name == property)
                element.SetValue(ret, value);
        return ret;
    }
