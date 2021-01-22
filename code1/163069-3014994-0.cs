    public class Key {
        string name;
        public Key(string n) { name = n; }
    
        public override bool Equals(object obj) {
            Key k = obj as Key;
            if (k == null)
                return false;
            return name.Equals(k.name);
        }
    
        public override int GetHashCode() {
            return name.GetHashCode();
        }
    }
