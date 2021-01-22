    class MyLabel : Label
    {
        [ReadOnly(true)]
        public override Font Font
        {
            get { return new Font(FontFamily.GenericMonospace, 10); }
            set { /* do nothing */ }
        }
    }
