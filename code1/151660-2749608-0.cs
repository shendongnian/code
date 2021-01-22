    public IEnumerable<IReadOnlyVector2> Vertices
    {
        get
        {
            return from v in _vertices 
                   select (IReadOnlyVector2)new DerivedVector2(v);
        }
    }
