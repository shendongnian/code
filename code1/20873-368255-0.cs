    [MetadataType(typeof(Product_Meta))]
     public partial class Product
     {        
       public partial class Product_Meta 
       {
         [Range(5, 50, ErrorMessage = "The product's reorder level must be greater than 5 and less than 50")]
         public object ReorderLevel { get; set; }         
       }  
     }
