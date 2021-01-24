    public IEnumerable<BaseClass> AllLeaves
    {
        get
        {
            foreach (LeafType firstLeaf in FirstLeaves)
            {
                yield return firstLeaf;
            }    
            foreach (OtherLeafType secondLeaf in SecondLeaves)
            {
                yield return secondLeaf;
            }
        }
    }
    public List<BaseClass> AllLeavesList()
    {
        return AllLeaves.ToList();
    }
