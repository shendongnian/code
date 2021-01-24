    //model
    public class Foo
    {
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    } 
