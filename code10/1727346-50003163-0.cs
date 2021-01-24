    public class MyRow
    {
        public string StringValue {get;set;}
        public double DoubleValue {get;set;}
        public override bool Equals(object o)
        {
             MyRow r = o as MyRow;
             if (ReferenceEquals(r, null)) return false;
             return r.StringValue == this.StringValue && r.DoubleValue == this.DoubleValue;
        }
        public override int GetHashCode()
        {
            unchecked { return StringValue.GetHashCode ^ r.DoubleValue.GetHashCode(); }
        }
    }
