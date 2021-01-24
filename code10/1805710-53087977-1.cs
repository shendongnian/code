    public class MyComparer : IEqualityComparer<string> // Instead of string, put your own type.
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y); // You'd implement your own comparison here.
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
