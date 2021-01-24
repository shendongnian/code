    class A
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public List<A> Children { get; } = new List<A>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<A> {
                new A { Id = 1, ParentId = 0},
                new A { Id = 2, ParentId = 3},
                new A { Id = 3, ParentId = 1},
                new A { Id = 4, ParentId = 0}
            };
        }
    }
