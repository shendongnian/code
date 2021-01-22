    string s1 = "0101000000110110000010010011";
    string s2 = "0101XXXXXXX101100000100100XX";
    bool areEqual = s1.SequenceEqual(s2, new IgnoreXEqualityComparer());    // True
    // ...
    public class IgnoreXEqualityComparer : EqualityComparer<char>
    {
        public override bool Equals(char x, char y)
        {
            return (x == 'X') || (y == 'X') || (x == y);
        }
        public override int GetHashCode(char obj)
        {
            throw new NotImplementedException();
        }
    }
