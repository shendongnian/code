    public IList<A> Lists
    {
        get 
        {
            return listA.Concat(listB.Cast<A>()).ToList();
        }
    }
