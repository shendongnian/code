    public class Customer
    {  
     
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public CustomerType CustomerType { get; set; }
    public int CustomerTypeId {get; set;}
    public Customer() { }
    }
      public class CustomerType 
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Customer> Customers {get; set}
        public string CustomerTypeName { get; set; }
        public CustomerType () { }
    }
