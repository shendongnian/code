    class ContentPanel : Panel
    {
        [Browsable(false)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = DockStyle.Fill; }
        }
    }
