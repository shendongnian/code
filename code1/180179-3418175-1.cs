    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			RegisterHyperLink.ForeColor = System.Drawing.Color.Red;
		}
    }
