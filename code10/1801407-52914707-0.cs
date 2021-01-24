        class Wrapper
        {
            public string Value { get; set; }
        }
        static void Main(string[] args)
        {
            Wrapper a = new Wrapper();
            a.Value = "Hello";
            Wrapper b = a;
            a.Value = "World";
            System.Diagnostics.Debug.Assert(ReferenceEquals(a, b));
            System.Diagnostics.Debug.Assert(a.Value == b.Value);
        }
