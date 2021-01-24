    class Foo
    {
        public int Id {get; set;}
        ...
        // every Foo has zero or more Props (one-to-many)
        public virtual ICollection<Prop> Props {get; set;}
    }
    class Prop
    {
        public int Id {get; set;}
        ...
        // every Prop belongs to exactly one Foo using foreign key:
        public int FooId {get; set;}
        public virtual Foo Foo {get; set;}
    }
 
