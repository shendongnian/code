        public class BC
        {
            public string Token { get; set; }
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
            public double SomeDouble { get; set; }
            public bool IsB => !String.IsNullOrEmpty(Token);
            public B ToB() => new B() { Token = Token };
            public C ToC() => new C() { SomeInt = SomeInt, SomeString = SomeString, SomeDouble = SomeDouble };
        }
