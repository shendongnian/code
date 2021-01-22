    public void AddItems( params MyItem[] items )
    {
        foreach( var item in items )
            m_innerCollection.Add( item );
    }
    // can be called with any number of arguments...
    coll.AddItems( first, second, third );
    coll.AddItems( first, second, third, fourth, fifth );
