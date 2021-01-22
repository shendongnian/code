        private List<string> Options;
        public CustomProperty(string sName, object value, Type tType, bool bReadOnly, bool bVisible, List<string> Options)
        {
            this.Options = Options;
        }
        public List<string> Options
        {
            get { return lOptions; }
        }
