    public Object[] GetCategories()
    {
        return new[]
        {
            new Category( 1, "A" ),
            new Category( 2, "BA" ),
            new Category( 3, "BAC" ),
        };
    }
    IEnumerable DoSomething()
    {
        return this.GetCategories()
            .Cast<Category>()
            .Where( c => c.Name.Contains("A") )
    }
