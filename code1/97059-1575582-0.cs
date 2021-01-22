    class PortableKey
    {
        public Dictionary<string, object> keyBag { get; set; }
    
        public PortableKey(Dictionary<string, object> Keys)
        {
            this.keyBag = Keys;
        }
    
        public override bool Equals(object obj)
        {
            PortableKey other = (PortableKey)obj;
            foreach (KeyValuePair<string, object> key in keyBag)
            {
                if (other.keyBag[key.Key] != key.Value) return false;
            }
            return true;
        }
    
        public override int GetHashCode()
        {
            // hashCodes is an array of integers represented as strings. { "1", "4", etc. }
            string[] hashCodes = keyBag.Select(k => k.Value.GetHashCode().ToString()).ToArray();
            // hash is the Hash Codes all joined in a single string. "1,4,etc."
            string hash = string.Join(",", hashCodes);
            // returns a single hash code for the combined hash. 
            // Note, this is not guaranteed unique, nor is it intended to be so.
            return hash.GetHashCode();
        }
        public override string ToString()
        {
            string[] values = keyBag.Select(k => k.Value.ToString()).ToArray();
            return string.Join(",", values);
        }
    }
