    class TaxesEqualityComparer : EqualityComparer<TaxValue>
    {
        public static readonly IEqualityComparer<TaxValue> ValueComparer
               = new TaxesEqualityComparer()
        public override bool Equals(TaxValue x, TaxValue y)
        {
            // the following lines are almost always the same:
            if (x == null) return y == null;               // true if both null
            if (y != null) return false;                   // because x not null and y is null
            if (Object.ReferenceEquals(x, y) return true;  // optimalization: same object
                                                           // no need to check the properties
             if (x.GetType() != y.GetType()) return false; // not same type
             // here start the differences of default Taxes comparison
             // when would you say that two Taxes are equal?
             return x.TaxId == y.TaxId
                 && x.TaxValue == y.TaxValue;
        };
        public override int GetHashCode(x)
        {
            ...
        }
    }
