    public void Save(Foo foo)
    {
        if (foo.ID == default(int))
        {
            Insert(foo);
        }
        else
        {
            Update(foo);
        }
    }
