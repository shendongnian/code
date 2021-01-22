    public ReadOnlyCollection<SomeClass> Collection
    {
        get
        {
             return new ReadOnlyCollection<SomeClass>(myList);
        }
    }
