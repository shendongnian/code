    [MetadataType(typeof(ProductMD))]
    public partial class Product {
        public class ProductMD {
            [StringLength(50),Required]
            public object Name { get; set; }
            [StringLength(15)]
            public object Color { get; set; }
            [Range(0, 9999)]
            public object Weight { get; set; }
          //  public object NoSuchProperty { get; set; }
        }
    }
