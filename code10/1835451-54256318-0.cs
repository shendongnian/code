     public class Company
        {
            [Key]
            public int Id { get; set; }
    
            [Display(Name = "Name")]
            [Required]
            public string Name { get; set; }
    
            [Display(Name = "Description")]
            public string Description { get; set; }
    
            [Required]
            [Display(Name = "Created date")]
            [DataType(DataType.DateTime)]
            public DateTime CreatedDate { get; set; }
    
            public virtual ICollection<Product> Prodcuts { get; set; }
    
        }
    
        public class Product
        {
            [Key]
            public int Id { get; set; }
    
            [Display(Name="Name")]
            [Required]
            public string Name { get; set; }
    
            [Required]
            [Display(Name = "Created date")]
            [DataType(DataType.DateTime)]
            public DateTime CreatedDate { get; set; }
    
            [Required]
            [ForeignKey("Company")]
            [Display(Name = "Company")]
            public int CompanyID { get; set; }
            public virtual Company Company { get; set; }
    
            public virtual ICollection<ProductField> Fields { get; set; }
            
        }
    
        public class ProductField
        {
            [Key]
            public int Id { get; set; }
    
            [Display(Name = "Value")]
            [Required]
            public string Value { get; set; }
    
            [Required]
            [ForeignKey("Product")]
            [Display(Name = "Product")]
            public int ProductID { get; set; }
            public virtual Product Product { get; set; }
    
            [Required]
            [ForeignKey("Field")]
            [Display(Name = "Field")]
            public int FieldID { get; set; }
            public virtual Field Field { get; set; }
    
            [Required]
            [Display(Name = "Created date")]
            [DataType(DataType.DateTime)]
            public DateTime CreatedDate { get; set; }
        }
    public class Field
        {
            [Key]
            public int ID { get; set; }
    
            [MaxLength(100)]
            [Index("ActiveAndUnique", 1, IsUnique = true)]
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }
    
            [Display(Name = "Description")]
            public string Description { get; set; }
      
            [Required]
            [Display(Name = "Created date")]
            [DataType(DataType.DateTime)]
            public DateTime CreatedDate { get; set; }
        }
