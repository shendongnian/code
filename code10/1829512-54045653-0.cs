    public IQueryable<MyClass> GetEnumerable()
    {
        IQueryable<MyClass> query = null; //whatever
        IQueryable<MyClass> q2 = 
                 from m in query
                 select new MyClass()
                 {
                     LuckNumber = m.LuckNumber * 2
                 };
        return q2;      
     }
