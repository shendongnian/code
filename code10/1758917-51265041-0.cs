        public static DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                // This is my data source
                dt= TagController.TagSelect(-1, -1, "", "").Tables[0];
                ddlQuestions.DataSource = dt;
                ddlQuestions.DataValueField = "Id";
                ddlQuestions.DataTextField = "Name";
                ddlQuestions.DataBind();
            }
        }
        protected void ddlQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr = dt.Select("Id=" + ddlQuestions.SelectedValue)[0];
            Response.Write(dr["Description"].ToString());            
        } 
