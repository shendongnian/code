    class sourceTester
    {
        public bool Hello { get; set; }
        public string World { get; set; }
        public int Foo { get; set; }
        public List<object> Bar { get; set; }
    }
    class targetTester
    {
        public int Hello {get; set;}
        public string World { get; set; }
        public double Foo { get; set; }
        public List<object> Bar { get; set; }
    }
    static void Main(string[] args)
        {
            sourceTester src = new sourceTester { 
                Hello = true, 
                World = "Testing",
                Foo = 123,
                Bar = new List<object>()
            };
            targetTester tgt = new targetTester();
            Copy(src, tgt);
            //Immediate Window shows the following:
            //tgt.Hello
            //0
            //tgt.World
            //"Testing"
            //tgt.Foo
            //0.0
            //tgt.Bar
            //Count = 0
            //src.Bar.GetHashCode()
            //59129387
            //tgt.Bar.GetHashCode()
            //59129387
        }
