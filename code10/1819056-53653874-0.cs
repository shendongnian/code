    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MasterPage MasterPage = (MasterPage)Page.Master;
            MasterPage.Base64ForUrlEncode(null);
        }
    }
