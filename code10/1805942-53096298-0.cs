    void Main()
    {
        var props = typeof(Foo).GetProperties();
    }
    class Foo {
        public string propA;
        public Bar propB;
    }
    class Bar
    {
        public string propC;
    }
