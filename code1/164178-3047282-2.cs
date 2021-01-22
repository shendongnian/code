    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            myGridView dg = new myGridView();
            dg.DataSource = new string[] { "1", "2", "3", "4", "5", "6" };
            dg.DataBind();
            ph.Controls.Add(dg);
        }
    }
