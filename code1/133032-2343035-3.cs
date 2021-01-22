    class Foo
    {
        OverridableValue<decimal> _excessWages =
                new OverridableValue<decimal>(CalculateExcessWages);
        public decimal ExcessWages
        {
            get { return _excessWages.Get(); }
            set { _excessWages.Set(value); }
        }
        ...
    }
