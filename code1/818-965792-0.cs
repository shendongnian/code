    public IList<B> ConvertIList<D, B>(IList<D> list) where D : B
    {
        List<B> newList = new List<B>();
    
        foreach (D item in list)
        {
            newList.Add(item);
        }
    
        return newList;
    }
