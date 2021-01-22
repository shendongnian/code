    public bool Equals(Foo<T> foo)
    {
        // These need to be calls to ReferenceEquals if you are overloading ==
        if (foo == null)
        {
            return false;
        }
        if (foo == this)
        {
            return true;
        }
        // I'll assume the lists can never be null
        if (lst.Count != foo.lst.Count)
        {
            return false;
        }
        for (int i = 0; i < lst.Count; i++)
        {
            if (!lst[i].Equals(foo.lst[i]))
            {
                return false;
            }
        }
        return true;
    }
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (T item in lst)
        {
            hash = hash * 31 + item.GetHashCode();
        }
        return hash;
    }
    public override bool Equals(Object obj)
    {
        // Note that Equals *shouldn't* throw an exception when compared
        // with an object of the wrong type
        return Equals(obj as Foo<T>);
    }
