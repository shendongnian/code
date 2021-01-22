    public class KeyPair<Tkey1, Tkey2>
    {
        public KeyPair(Tkey1 key1, Tkey2 key2)
        {
            Key1 = key1;
            Key2 = key2;
        }
    
        public Tkey1 Key1 { get; set; }
        public Tkey2 Key2 { get; set; }
    
        public override int GetHashCode()
        {
            return Key1.GetHashCode() ^ Key2.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            KeyPair<Tkey1, Tkey2> o = obj as KeyPair<Tkey1, Tkey2>;
            if (o == null)
                return false;
            else
                return Key1.Equals(o.Key1) && Key2.Equals(o.Key2);
        }
    }
