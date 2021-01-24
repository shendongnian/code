    public class ProductDTO {
        // Same fields, mostly
        public string Action { get; set; }    // A, C, D
    }
    
    public class OrganizationDTO {
        // Same fields except children
        public ICollection<ProductDTO> Products { get; set; }
        public string Action { get; set; }
    }
    
