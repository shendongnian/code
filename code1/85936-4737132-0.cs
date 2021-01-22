    class SomeObject
    {
        [Dependency("Value")]
        public string Value { get; set; }
        public void OverrideValue(string value)
        {
            this.Value = value;
        }
    }
