    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddown.Items.Add(new ListItem("Default", "-1"));
                ddown.Items.Add(new ListItem("text 0", "0"));
                ddown.Items.Add(new ListItem("text 1", "1"));
                ddown.Items.Add(new ListItem("text 2", "2"));
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
        }
        protected void ddown_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb.Text = ddown.SelectedItem.Text;
            btn.Visible = false;
        }
