        protected void Page_Load(object sender, EventArgs e)
        {
            WebUserControl11.PreRender += new EventHandler(WebUserControl11_PreRender);
        }
        void WebUserControl11_PreRender(object sender, EventArgs e)
        {
            string str = WebUserControl11.MyProperty;
            this.Header.Title = str;
        } 
