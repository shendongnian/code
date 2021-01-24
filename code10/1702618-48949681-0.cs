    class DisplayValue
    {
        public string Description{get; set;}
        public object Value {get; set;}
        public string DisplayedValue {get {return this.Value.ToString();} }
    }
