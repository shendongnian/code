    class Field
    {
        public bool Required { get; }
        public string Value { get; set; }
        // assuming that this method is virtual here
        // if different Fields have different validation logic
        // they should probably be separate classes anyhow and
        // simply implement a common interface of inherit from a common base class.
        public override bool IsValid
        {
            get { return Required && Value != String.Empty; }
        }
    }
