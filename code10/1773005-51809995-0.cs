    public class Product
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        ...
        [InverseProperty("Product")]
        public virtual List<RelatedCatalogs> RelatedCatalogs { get; set; }
    }
    public class RelatedCatalogs : EntityBase
    {
        public Guid ID { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        [ForeignKey("RelatedProductCatalog")]
        public Guid RelatedProductID { get; set; }
        public Product RelatedProductCatalog { get; set; }
        
        public int Priority { get; set; }
    }
