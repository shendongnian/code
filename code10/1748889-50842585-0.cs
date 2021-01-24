    interface IShip
    {
        int NetValue {get;}
    }
    
    class Ship : IShip
    {
        public int NetValue {get;set;}
    }
    
    public IQueryable<T> GetExpensiveShips<T>(IQueryable<T> query)
        where T : IShip, class
    {
        return query.Where(q => q.NetValue > 150000);
    }
