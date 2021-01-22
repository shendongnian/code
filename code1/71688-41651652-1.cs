    class twostring
    {
        public string a { get; set; }
        public string b { get; set; }
    }
    TestSize<twostring>.SizeOf(new twostring() { a="0123456789", b="0123456789" } //-> 28 B
