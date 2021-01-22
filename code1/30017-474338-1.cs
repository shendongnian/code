    public partial MyDataContext:IMyTable<Customer>, IMyTable<Order>
    {
      public Table<Customer> : IMyTable<Customer>.TheTable
      { get{ return this.GetTable<Customer>(); } }
    
      public Table<Order> : IMyTable<Order>.TheTable
      { get{ return this.GetTable<Order>(); } }  
    }
