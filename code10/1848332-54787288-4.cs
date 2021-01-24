    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
 
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category{get;set;}
    }
