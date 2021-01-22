    public IQueryable<Order> FetchAll()
    {     
        // you should probably be able to return dataContext.NameOfOrderTable here instead.
        return dataContext.GetTable<Order>();
    }
    protected Order GetOrder(int id)
    {    
        // again you should be able to use dataContext.NameOfOrderTable here
        return dataContext.GetTable<Order>().SingleOrDefault(o => o.ID == id);
    }
