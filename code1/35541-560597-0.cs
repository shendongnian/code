        void Test1()
        {
            _prop = ""; // warning given
        }
        public string Prop
        {
    #pragma warning disable 0618
            get { return _prop; }
            set { _prop = value; }
    #pragma warning restore 0618
        }
        [Obsolete("This is the backing field for lazy data; do not use!!")]
        private string _prop;
        void Test2()
        {
            _prop = ""; // warning given
        }
