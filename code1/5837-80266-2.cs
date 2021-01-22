    public class FooDataContext : DataContext
    {
       public Table<Order> Orders;   
    }
    
    public class Order
    {
        [DbColumn(Identity = true)]
        [Column(DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
    
        [DbColumn(Default = "(getutcdate())")]
        [Column(DbType = "DateTime", CanBeNull = false, IsDbGenerated = true)]
        public DateTime DateCreated { get; set; }
        
        [Column(DbType = "varchar(50)", CanBeNull = false, IsDbGenerated = false)]
        public string Name { get; set; }
    }
