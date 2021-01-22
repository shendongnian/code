    public MyClassMapping()
    {
        Table("MyClass");
        Id(x => x.Id);
        HasMany(x => x.Strings)
            .Table("MyClassStrings")
            .Element("String");
    }
