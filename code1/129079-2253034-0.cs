    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
    
            }
