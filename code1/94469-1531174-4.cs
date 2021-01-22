    public IEnumerable<Person> Children
    {
        get
        {
            return _children.AsReadOnly();
        }
    }
