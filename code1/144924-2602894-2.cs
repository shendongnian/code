    class JaggedDictionary{
        private Dictionary<string, string> leafs = 
                new Dictionary<string, string>();
        private Dictionary<string, JaggedDictionary> nodes = 
                new Dictionary<string, JaggedDictionary>();
        public object this[string str]
        {
            get
            {
                return nodes.Contains(str) ? nodes[str] : 
                       leafs.Contains(str) ? leafs[str] : null;
            }
            set
            {
                // if value is an instance of JaggedDictionary put it in 'nodes',
                // if it is a string put it in 'leafs'...
            }
        }
    }
