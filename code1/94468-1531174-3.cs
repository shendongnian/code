    public IEnumerable<Person> Children
    {
        get
        {
            foreach (Person child in _children)
            {
                yield return child;
            }
        }
    }
