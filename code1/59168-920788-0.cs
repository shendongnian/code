public static IRepository RepositoryForType(Type t)
{
    if(t == typeof(SomeClass))
       return new SomeClassRepository(new HybridSession());
    else if ...
    else throw new InvalidOperationException("No repository for type " + t.Name);
}
