        public delegate void ClickEventHandler(object sender, EventArgs e);
        public event ClickEventHandler Click =  delegate { };
        public string Text
        {
            get { return cmdLink.Text; }
            set { cmdLink.Text = value; }
        }
        public bool CausesValidation
        {
            get { return cmdLink.CausesValidation; }
            set { cmdLink.CausesValidation = value; }
        }
        public string OnClientClick
        {
            get { return cmdLink.OnClientClick; }
            set { cmdLink.OnClientClick = value; }
        }
        public string CssClass
        {
            get { return cmdLink.CssClass; }
            set { cmdLink.CssClass = value; }
        }
        protected void cmdLink_Click(object sender, EventArgs e)
        {
            Click(this, e);
        }
