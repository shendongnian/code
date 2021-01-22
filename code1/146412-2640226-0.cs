    public class Test
    {
        private Test(int? a,string b) { }
        public Test(int a) : this(a, null) { }
        public Test(string b) : this(null, b) { }
    }
