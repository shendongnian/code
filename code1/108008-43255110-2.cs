    public class NullStringComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            // equal if string.Equals(x, y)
            // or both StringIsNullOrEmpty
            return String.Equals(x, y)
                || (String.IsNullOrEmpty(x) && String.IsNullOrEmpty(y));
        }
        public override int GetHashCode(string obj)
        {
            if (String.IsNullOrEmpty(obj))
               return 0;
            else
                return obj.GetHashCode();
        }
    }
