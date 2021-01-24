        static void Main(string[] args)
        {
            Hashtable h = new Hashtable()
            {
              { "string1", 1 },
              { "string2", 2 }
            };
            int i = GetHashCode(h);
            h = new Hashtable()
            {
              { "string2", 2},
              { "string1", 1 }
            };
            int j = GetHashCode(h);
            Debug.Assert(i == j);
            h = new Hashtable()
            {
              { "string1", 1 },
              { "string2", 2 }
            };
            i = GetHashCode(h);
            h = new Hashtable()
            {
              { "string2", 3},
              { "string1", 1 }
            };
            j = GetHashCode(h);
            Debug.Assert(i != j);
        }
        static int GetHashCode(Hashtable ht)
        {
            if (ht.Count == 0) return ht.GetHashCode();
            int h = 0;
            foreach(DictionaryEntry de in ht)
            {
                h ^= new { de.Key, de.Value }.GetHashCode();
            }
            return h;
        }
