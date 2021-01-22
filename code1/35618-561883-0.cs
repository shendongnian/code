    // Private version which takes a context...
    private static Func<LINQDBDataContext, string, IQueryable<Pet>> 
        QueryFindByNameImpl =
        CompiledQuery.Compile((
        LINQDBDataContext context, string name) =>
        from p in context.Pets where p.Name == name select p);
    // Public version which calls the private one, passing in the known context
    public static Func<string, IQueryable<Pet>> QueryFindByName = 
        name => QueryFindByNameImpl(contextFromType, name);
