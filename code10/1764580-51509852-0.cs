    class RootObject
    {
        public string User { get; set; }
        public List<int> Sybsystems { get; set; }
        public MessyQueryExpression Query { get; set; }
    }
    class MessyQueryExpression
    {
        public List<string> EQ { get; set; }
        public List<MessyQueryExpression> AND { get; set; }
        public List<MessyQueryExpression> OR { get; set; }
    }
