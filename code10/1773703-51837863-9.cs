    public class FooModel
    {
        [Required]
        public int Id { get; set; }
    
        [DesignAttribute(Width = 20, BackgroundColor = "red"]
        public string Name { get; set; }
    }
