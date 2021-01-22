    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClientScript.RegisterStartupScript(GetType(), "key", "someFunction();", true);
        }
    }
