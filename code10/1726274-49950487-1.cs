    class B
    {
        public string id { get; set; }
        public string val2 { get; set; }
        public string val3 { get; set; }
    }
    class A : B
    {
        public string val1 { get; set; }
        public string val4 { get; set; }
        public string val5 { get; set; }
    }
    var listb = new List<B>();
