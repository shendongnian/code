    public class ItemModel
    {
        [Required]
        public int? Id { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
    }
