    public List<IPart> Fetch(Type PartType)
    {
        if (!typeof(IPart).IsAssignableFrom(PartType))
        {
            throw new ArgumentOutOfRangeException("PartType", "Must derive from IPart");
        }
        return this.PartList.Where(i => i != null && PartType.IsAssignableFrom(i.GetType())).ToList();
    }
