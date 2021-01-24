    public class Employee
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Address { get; set; }
        public Other Ppl { get; } = new Other(); // Ppl is now a property rather than a field
    }
    public class Other
    {
        public string Kid { get; set; }
        public string Wife { get; set; }
    }
