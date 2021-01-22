    void DoesThisWork()
    {
         List<C> DerivedList = new List<C>();
         List<A> BaseList = DerivedList;
         BaseList.Add(new B());
    
         C FirstItem = DerivedList.First();
    }
