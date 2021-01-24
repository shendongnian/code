    class PhysicalValue : IDataErrorInfo
    {
        public double Value { get; set; }
        public object Unit { get; set; }
        public string Error => this["Value"] + this["Unit"];
        public PhysicalValue(int v, object u)
        {
            Value = v;
            Unit = u;
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Value")
                {
                    if (Value > 5000)
                    {
                        return "out of spec value";
                    }
                }
                return String.Empty;
            }
        }
    }
