        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public override string Text
        {
            get { return _string; }
            set { _string = value; }
        }
