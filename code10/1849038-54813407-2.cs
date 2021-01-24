    class PhysicalValueValidator : IDataErrorInfo
    {
        private readonly PhysicalValue _physicalValue;
        private double _maxValue;
        public double Value
        {
            get { return _physicalValue.Value; }
            set { _physicalValue.Value = value; }
        }
        public PhysicalValueValidator(PhysicalValue pv)
        {
            _physicalValue = pv;
            _maxValue = 5000;
        }
        public void SetMaxValue(double maxValue)
        {
            _maxValue = maxValue;
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Value")
                {
                    if (Value > _maxValue)
                    {
                        return "out of spec value";
                    }
                }
                return String.Empty;
            }
        }
        public string Error => this["Value"];
    }
