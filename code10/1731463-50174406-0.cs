    class BuissnessObject
    {
        public String Foo { get; set; }
        public String Bar { get; set; }
        public override string ToString()
        {
            return $"Foo : {Foo}, Bar : {Bar}";
        }
    }
