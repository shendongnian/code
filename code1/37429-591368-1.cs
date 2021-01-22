    [Table(Name = "foo_aggregates")]
    public class FooCount
    {
        [Column(Name = "foo_id")]
        public Int32 FooId { get; set; }
    
        [Column(Name = "count")]
        public Int32 Count { get; set; }
    }
