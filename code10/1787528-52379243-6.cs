    public class MyModel {
        [MinLength(6)]
        [MaxLength(12)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
