    public List<C> getList(List<A> listA, List<B> listB)
    {
        var listC = new List<C>();
        
        for(var i = 0; i < listA.Count; i++)
        {
            listC.Add(new C 
            {
                Id = listA[i].Id,
                stuffA = listA[i].stuffA,
                stuffB = listB[i].stuffB
            };
        }
        
        return listC;
    }
