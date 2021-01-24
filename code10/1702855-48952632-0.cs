    public class Product
        {
            public virtual ICollection<Transaction> Transactions { get; set; }
        }
    
        public class Transaction
        {
            public int TransId { get; set; }
            public int ProductId { get; set; }
            public Product Product { get; set; }
    
            public string TransType { get; set; }
            public DateTime DateTime { get; set; }
    
            public virtual RelatedData RelatedData  { get;set;}
        }
    
        public class RelatedData
        {
            public int TransId { get; set; }
            public virtual Transaction Transaction { get; set; }
            public string SpecialData { get; set; }
    
        }
