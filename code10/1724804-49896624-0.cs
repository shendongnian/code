    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        String Sql = @" select * from SupportTeam";
        SqlConnection conn = new SqlConnection(Properties.Resources.cString);
        SqlDataAdapter DA = new SqlDataAdapter(Sql, Properties.Resources.cString);          
        DataSet DS = new DataSet();
        DA.Fill(DS, "SupportTeam");
        DataTable DT = DS.Tables["SupportTeam"];
        DropDownList1.DataValueField = "supportTeamID";
        DropDownList1.DataTextField = "supportTeamName";
        DropDownList1.DataSource = DT;
        DropDownList1.DataBind();
        }
    }
