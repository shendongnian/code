    // Foo creator delegate.
    public delegate Foo CreateFoo(Bar bar);
    // Lookup of creators, for each type of Bar.
    public static Dictionary<Type, CreateFoo> Factory = new Dictionary<Type, CreateFoo>();
    // Registration.
    Factory.Add(typeof(Bar1), (b => new Foo1(b)));
    // Factory method.
    static Foo Create(Bar bar)
    {
        CreateFoo cf;
        if (!Factory.TryGetValue(bar.GetType(), out cf))
            return null;
        return cf(bar);
    }
