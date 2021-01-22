    public class IndexerTest
    {
        private Dicionary<string, string> keyValues = new ...
    
        public string this[string key]
        {
             get { return keyValues[key]; }
             set { keyValues[key] = value; }
        }
    }
