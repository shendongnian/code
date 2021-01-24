        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category Description")]
        public string Description { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
