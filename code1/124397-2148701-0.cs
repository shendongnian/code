        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);
            if (!IsPostBack)
            {
                Label4.Text = Convert.ToString(Application.Get("topic")); //might be null?
            }
        }
