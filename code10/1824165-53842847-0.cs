    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            ddlType.DataBind(); // Load data from DataSource
            if (Request.QueryString["searchtype"] != null)
            {
                ddlType.SelectedValue = ddlType.Items.FindByText(Request.QueryString["searchtype"]).Value;
                ddlType.SelectedValue = "1";
            }
        }
        else
        {
        }
    }
