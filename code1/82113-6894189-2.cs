    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["intCompany_Accounting_Year_ID"] == null || Session["vcrAdmin_Id"] == null)
            {
                Response.Redirect("User_Login.aspx");
            }
            if (!IsPostBack)
            {
                ViewState["Page_Index"] =  Request.QueryString["Page_Index"];
                ViewState["ID_Field"] = Request.QueryString["ID_Field"];
                Initialize_Page();                
                Bind_Search_Grid();                
            }
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            Bind_Search_Grid();
        }                               
    protected void grdSearch_Result_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            lblHeader.Text = ViewState["Header_Name"].ToString();
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDisplay_Text");
            lnk.OnClientClick = "Close_Window('" + lnk.CommandArgument + "','" + ViewState["ID_Field"].ToString() 
                + "')";
        }
    }
    protected void grdSearch_Result_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
    
    }
