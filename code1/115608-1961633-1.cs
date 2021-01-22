    public class StringBuffer
    {
        List<char> chars = new List<char>();
        // Wraps up an underlying data store
        public string Value
        {
            get { return new String(chars.ToArray()); }
            set { chars = new List<char>(value.ToCharArray()); }
        }
    
        public void Write(string s) { Write(chars.Count, s); }
    
        public void Write(int index, string s)
        {
            if (index > chars.Count) { throw new Exception("Out of Range"); }
            foreach(char c in s)
            {
                if (index < chars.Count) { chars.[index] = c; }
                else { chars.Add(c); }
                index++;
            }
        }
    }
