    public class Key
    {
        string name;
        public Key(string n) { name = n; }
    
        public override GetHashCode()
        {
            if (name == null) return 0;
            return name.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            Key other = obj as key;
            return other != null && other.name == this.name;
        }
    }
