        public class Human
    {
        [Required(ErrorMessage ="")]
        [StringLength(10)]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
