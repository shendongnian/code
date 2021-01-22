    // Ugh! Public data for brevity
    class Foobar
    {
        public bool foo, bar;
        public static implicit operator bool(Foobar fb) { return fb.foo; }
    }
    class Db
    {
        public IEnumerable<Foobar> Foobars;
    }
    Db db;
