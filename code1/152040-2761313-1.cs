    public class DemoDataContext : DataContext
    {
      public DemoDataContext (string cxString) : base (cxString) { }
      public Table<Customer> Customers { get { return GetTable<Customer>(); } }
      public Table<Purchase> Purchases { get { return GetTable<Purchase>(); } }
    }
    [Table] public class Customer
    {
      [Column(IsPrimaryKey=true)]  public int ID;
      [Column]                     public string Name;
      [Association (OtherKey="CustomerID")]
      public EntitySet<Purchase> Purchases = new EntitySet<Purchase>();
    }
    [Table] public class Purchase
    {
      [Column(IsPrimaryKey=true)]  public int ID;
      [Column]                     public int CustomerID;
      [Column]                     public string Description;
      [Column]                     public decimal Price;
      [Column]                     public DateTime Date;
      EntityRef<Customer> custRef;
      [Association (Storage="custRef",ThisKey="CustomerID",IsForeignKey=true)]
      public Customer Customer
      {
        get { return custRef.Entity; } set { custRef.Entity = value; }
      }
    }
