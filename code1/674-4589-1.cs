    public class ExtendedDictionary : Dictionary<string, int>
    {
        private int lastKeyInserted = -1;
    
        public int LastKeyInserted
        {
            get { return lastKeyInserted; }
            set { lastKeyInserted = value; }
        }
    
        public void AddNew(string s, int i)
        {
            lastKeyInserted = i;
    
            base.Add(s, i);
        }
    }
