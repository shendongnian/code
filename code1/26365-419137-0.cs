            Func<string,bool,string> CaptureCaps = (source,caseInsensitive) => string.Join(" ", 
                    new Regex(@"\b[A-Z]\w*").Matches(source).OfType<Match>().Select(match => match.Value).Distinct(new KeisInsensitiveComparer(caseInsensitive) ).ToArray() );
            MessageBox.Show(CaptureCaps("First The The  Quick Red fox jumped oveR A Red Lazy BRown DOg", false));
            MessageBox.Show(CaptureCaps("Mimi loves Toto. Tata hate Mimi, so Toto killed TaTa. A bad one!", false));
            MessageBox.Show(CaptureCaps("First The The  Quick Red fox jumped oveR A Red Lazy BRown DOg", true));
            MessageBox.Show(CaptureCaps("Mimi loves Toto. Tata hate Mimi, so Toto killed TaTa. A bad one!", true));
    class KeisInsensitiveComparer : IEqualityComparer<string>
    {
        public KeisInsensitiveComparer() { }
        bool _caseInsensitive;
        public KeisInsensitiveComparer(bool caseInsensitive) { _caseInsensitive = caseInsensitive; }
        // Products are equal if their names and product numbers are equal.
        public bool Equals(string x, string y)
        {
            // Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
            // Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            
            return _caseInsensitive ? x.ToUpper() == y.ToUpper() : x == y;
        }
        // If Equals() returns true for a pair of objects,
        // GetHashCode must return the same value for these objects.
        public int GetHashCode(string s)
        {
            // Check whether the object is null.
            if (Object.ReferenceEquals(s, null)) return 0;
            // Get the hash code for the Name field if it is not null.
            int hashS = s == null ? 0 : _caseInsensitive ? s.ToUpper().GetHashCode() : s.GetHashCode();
            // Get the hash code for the Code field.
            int hashScode = _caseInsensitive ? s.ToUpper().GetHashCode() : s.GetHashCode();
            // Calculate the hash code for the product.
            return hashS ^ hashScode;
        }
    }
