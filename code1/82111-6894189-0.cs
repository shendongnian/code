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
