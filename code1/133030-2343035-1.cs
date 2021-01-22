    class Foo
    {
        OverridableValue<decimal> _excessWages;
        public decimal ExcessWages
        {
            get { return _excessWages.Get(); }
            set { _excessWages.Set(value); }
        }
        ...
    }
