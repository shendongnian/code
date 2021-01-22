    public IEnumerator<string> Names
    {
        get
        {
            return persons.Select(p => p.Name);
        }
    }
