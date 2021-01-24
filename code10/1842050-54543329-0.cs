    class Root
    {
        public int Id {get; set;}
        ... // other properties
        // every Root has zero or more As (one-to-many):
        public virtual ICollection<A> As {get; set;}
    }
    class A
    {
        public int Id {get; set;}
        ... // other properties
        // every A belongs to exactly one Root, using foreign key
        public int RootId {get; set;}
        public virtual Root Root {get; set;}
        // every A has zero or more Bs:
        public virtual ICollection<B> Bs {get; set;}
    }
     class B
    {
        public int Id {get; set;}
        ... // other properties
        // every B belongs to exactly one A, using foreign key
        public int AId {get; set;}
        public virtual A A {get; set;}
        // every B has zero or more Cs:
        public virtual ICollection<C> Cs {get; set;}
    }
    etc.
