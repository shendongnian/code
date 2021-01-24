    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            String Sql = @" select * from project";
            SqlConnection conn = new SqlConnection(Properties.Resources.cString);
            SqlDataAdapter DA = new SqlDataAdapter(Sql, Properties.Resources.cString);
            DataSet DS = new DataSet();
            DA.Fill(DS, "Project");
            DataTable DT = DS.Tables["Project"];
            lbProjects.DataValueField = "ProjectID";
            lbProjects.DataTextField = "ProjectName";
            lbProjects.DataSource = DT;
            lbProjects.DataBind();
        }
    }
