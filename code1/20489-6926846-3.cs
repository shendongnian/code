        private List<string> lOptions;
        public CustomProperty(string sName, object value, Type tType, bool bReadOnly, bool bVisible, List<string> lOptions)
        {
            this.lOptions = lOptions;
        }
        public List<string> Options
        {
            get { return lOptions; }
        }
