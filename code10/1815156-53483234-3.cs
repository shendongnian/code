    public IReadonlyCollection<TSource> ComboItems
    {
        get {return (IReadOnlyCollection<TSource>)base.DataSource;}
        set 
        {
            // TODO: check if the empty element is in your list; if not add it
            base.DataSource = value;
        }
    }
