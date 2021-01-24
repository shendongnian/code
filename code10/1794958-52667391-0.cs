    public class Foo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("AFoo")]
        public int? AFooID { get; set; }
        public virtual AnotherFoo AFoo { get; set; }
        public int? ParentID { get; set; }
        public virtual Foo Parent { get; set; }
        public virtual List<Foo> Children { get; set; } = new List<Foo>();
    }
    public class AnotherFoo
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
