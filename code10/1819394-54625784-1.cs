    public class Test
    {
        [return:Nullable(2)]
        public string Foo([Nullable(1)] string input) { ... }
        [return: Nullable(new byte[] { 1, 2 })]
        public List<string> Bar() { ... }
    }
