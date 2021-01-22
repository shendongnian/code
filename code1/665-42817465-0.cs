        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                string key= Request.QueryString["key"];
                if (key=="1")
                {
                    // Some code
                }
            }
        }
