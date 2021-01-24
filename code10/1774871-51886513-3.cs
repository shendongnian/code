    class Test
    {
        public Test(IClass actor)
        {
            Actor = actor;
        }
        public IClass Actor { get; }
        public MyEnum eEnum { get; set; }
        public string Str { get; set; }
    }
