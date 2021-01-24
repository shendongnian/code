    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // other logic here
            if (G1List.Count != 0)
            {
                DOC_TYPE = G1_DOC_TYPE;
            }
            else if (G2List.Count != 0)
            {
                DOC_TYPE = G2_DOC_TYPE;
            }
            else if (G3List.Count != 0)
            {
                DOC_TYPE = G3_DOC_TYPE;
            }
            else
            {
                Response.Redirect("/SitePages/AccessDeny.aspx");
            }
    
            Page.DataBind();
        }
    }
