    public partial class MyDataContext:IMyTable<Customer>, IMyTable<Order>
    {
      Table<Customer> IMyTable<Customer>.TheTable
      { get{ return this.GetTable<Customer>(); } }
    
      Table<Order> IMyTable<Order>.TheTable
      { get{ return this.GetTable<Order>(); } }  
    }
