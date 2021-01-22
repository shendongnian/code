    public IList<Foo> ImmutableViewOfInventory() 
    {
        List<Foo> inventory = new List<Foo>();
        inventory.Add(new Foo());
        return inventory.AsReadOnly();
    }
