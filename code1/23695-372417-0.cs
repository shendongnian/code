        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke((Action)LoadStuff);
        }
        void LoadStuff()
        {
            // todo...
        }
