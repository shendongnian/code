    public void AddItems( IEnumerable<MyClass> items )
    {
        foreach( var item in items )
             m_innerCollection.Add( item );
    }
