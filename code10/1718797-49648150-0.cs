        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }
        [Required, StringLength(100), Display(Name = "Seller")]
        public string Seller { get; set; }
        public DateTime Date { get; set; }
        public int? SubcategoryID { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
