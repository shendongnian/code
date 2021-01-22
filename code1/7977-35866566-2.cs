    class CustomPropertyGrid
    {
        private string multiLineStr = string.Empty;
        [Editor(typeof(MultiLineTextEditor), typeof(UITypeEditor))]
        public string MultiLineStr
        {
            get { return multiLineStr; }
            set { multiLineStr = value; }
        }
    }
