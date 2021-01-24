    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public int SupplierContact { get; set; }
        public int CategoryId { get; set; }        <== Reference to this property
        public Category Category { get; set; }
    }
