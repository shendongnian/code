    public class Key
    {
        private readonly string s;
    
        public Key(string s)
        {
            this.s = s;
        }
    
        public string KeyString
        {
            get { return s; }
        }
    }
