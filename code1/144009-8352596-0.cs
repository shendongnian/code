        private const string defaultValue = "Hack me!"; // from original data source
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ViewState[txtTest.ClientID] = false;
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if(ViewState[txtTest.ClientID] != null && !(bool)ViewState[txtTest.ClientID])
                txtTest.Text = defaultValue;
            string x = txtTest.Text;
        }
