    public class GropsAndProducts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GroupId { get; set; }
        public Groups Group { get; set; }
        public Products Product { get; set; }
    }
