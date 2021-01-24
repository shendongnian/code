    public class Existence
    {
        public string Id { get; private set; }
    
        [ForeignKey("Warehouse")]	
        public string WarehouseId { get; private set; }
        public ProductId Product { get; private set; }
        public decimal Quantity { get; private set; }
        public string Batch { get; private set; }
    	
        public virtual Warehouse Warehouse{get;set;)
    }
    
    public class Warehouse
    {
    	//your other Warehouse properties
    
        //add below line, if one to one relation
        public virtual Existence Existence{get; set;}
        //or, add below line, if one to many relation
        //public virtual IList<Existence> Existence{get; set;}
    }
