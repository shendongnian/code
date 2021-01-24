    public class Foo
    {
        [Key]
        public int Id { get; set; }
        public IList<FooBar> Bars { get; set; }
    }
    public class Bar
    {
        [Key]
        public int Id { get; set;}
        public IList<FooBar> Foos { get; set;}
    }
    public class FooBar
    {
        [Key]
        public int Id { get; set; }
        public int FooId { get; set; }
        public int BarId { get; set; }
        
        [ForeignKey("FooId")]
        public Foo Foo { get; set; }
        [ForeignKey("BarId")]
        public Bar Bar { get; set;}
    }
    context.FooBar.Where(f => f.FooId == id).Include("Foo").Include("Bar").ToList();
