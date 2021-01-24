    class Rule
    { 
        public ElementType? Left { get; set; }
        public ElementType? Right { get; set; }
        public ElementType? Top { get; set; }
        public ElementType? Bottom { get; set; }
        public Action Process { get; set; }
    }
