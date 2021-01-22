    public class Key
    {
        string name;
        public Key(string n) { name = n; }
        
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var other = obj as Key;
            if( other == null )
                return false;
            return name == other.name;
        }
    }
