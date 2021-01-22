     struct myStruct {
        private Dictionary<string, int> a;
        private Dictionary<string, string> b;
        public Dictionary<string, int> A
        {
            get { return a ?? (a = new Dictionary<string, int>()); }
        }
        public Dictionary<string, string> B
        {
            get { return b ?? (b = new Dictionary<string, string>()); }
        }
    }
