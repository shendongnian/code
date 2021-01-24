    public class MyString : IEquatable<MyString>, IComparable, IComparable<MyString>
    {
        public static readonly StringComparer Comparer = StringComparer.InvariantCultureIgnoreCase;
        public readonly string Value;
    
        public MyString(string value)
        {
            Value = value;
        }
    
        public static implicit operator MyString(string value)
        {
            return new MyString(value);
        }
    
        public static implicit operator string(MyString value)
        {
            return value != null ? value.Value : null;
        }
    
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(Value);
        }
    
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MyString))
            {
                return false;
            }
    
            return Comparer.Equals(Value, ((MyString)obj).Value);
        }
    
        public override string ToString()
        {
            return Value != null ? Value.ToString() : null;
        }
    
        public bool Equals(MyString other)
        {
            if (other == null)
            {
                return false;
            }
    
            return Comparer.Equals(Value, other.Value);
        }
    
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
    
            return CompareTo((MyString)obj);
        }
    
        public int CompareTo(MyString other)
        {
            if (other == null)
            {
                return 1;
            }
    
            return Comparer.Compare(Value, other.Value);
        }
    }
