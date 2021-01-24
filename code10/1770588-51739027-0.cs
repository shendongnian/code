    public class Foo
    {
        public int Id {get; set;}
        public List<FooBar> FooBars {get;set;}
    }
    
    public class Bar
    {
        public int Id {get; set;}
        public List<FooBar> FooBars {get; set;}
    }
    public class FooBar
    {
        [Key, Column(Order=1)]
        public int FooId {get; set;}
        public Foo Foo {get; set;}
        [Key, Column(Order=2)]
        public int BarId {get; set;}
        public Bar Bar {get; set;}
        public RelationshipEnum Relationship {get; set;}
    }
