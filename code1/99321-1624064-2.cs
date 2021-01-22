    class A
    {
        public int Id { get; set; }
        public List<B> Children { get; set; }
    }
    class B
    {
        public List<C> Children { get; set; }
    }
    class C
    {
        public string Name { get; set; }
    }
