    public Object[] GetCategories()
    {
        return new (Int32 id, String name)[]
        {
            new ( 1, "A" ),
            new ( 2, "BA" ),
            new ( 3, "BAC" ),
        };
    }
    IEnumerable DoSomething()
    {
        return this.GetCategories()
            .Cast<(Int32 id, String name)>()
            .Where( c => c.Name.Contains("A") )
    }
