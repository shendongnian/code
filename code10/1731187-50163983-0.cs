    [Table("bar")]
    public class Bar
    {
        [Key]
        [Column("key1", TypeName = "int", Order = 1)]
        public int Key1 { get; set; }
        [Key]
        [Column("key2", TypeName = "int", Order = 2)]
        public int Key2 { get; set; }
        public int FooId { get; set; }
        
        public Foo Foo { get; set; }
    }    
