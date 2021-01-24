    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Product2 : DomainEntityIntPK
    {
        public string Name { get; set; }
    }
