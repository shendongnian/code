    public IEnumerable<District> Ancestors
    {
        get
        {
            District parent = Parent;
            while (parent != null)
            {
                yield return parent;
                parent = parent.Parent;
            }
        }
    }
