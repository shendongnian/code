    class FieldItem
    {
        public string ObjectName {get; set;}
        public string ObjectProperty {get; set;}
        public string ObjectValue {get; set;}
        public Predicate<FieldItem> EvalMethod { private get; set; }
        public FieldItem()
        {
        }
        public bool Evaluate()
        {
            return EvalMethod(this);
        }
    }
