    public IEnumerable<District> Ancestors
    {
        get
        {
            return this.GetAncestors(d => d.Parent);
        }
    }
