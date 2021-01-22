    [GenerateImmutable]
    struct Foo
    {
        public int apples;
        public int oranges;
        public Foo Clone() {return (Foo) base.MemberwiseClone();}
    }
