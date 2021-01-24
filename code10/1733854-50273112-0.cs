    public class Station
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual State State { get; set; }
        [Required]
        public int StateId { get; set; }
    }
