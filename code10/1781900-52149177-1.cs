    public class MyClass
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RangeCustomer(1, Int64.MaxValue)]
        public long Volume{ get; set; }
    }
