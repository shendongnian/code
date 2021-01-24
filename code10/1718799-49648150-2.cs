        [ScaffoldColumn(false)]
        public int SubcategoryID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string SubcategoryName { get; set; }
        [Display(Name = "Subcategory Description")]
        public string Description { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
