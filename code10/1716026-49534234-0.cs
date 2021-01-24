    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                if (Convert.ToInt16(Session["level"]) == 0)
                {
                    FillStoreDropDown();
                    FillTypeDropDown();
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            addProductElements();
            if (Session["LoadExisting"] != null)
            {
                LoadExisting();
                CheckType();
            }
        }
    }
