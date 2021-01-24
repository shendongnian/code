    protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        ddlContinents.AppendDataBoundItems = true;
        String strConnString = ConfigurationManager
            .ConnectionStrings["conString"].ConnectionString;
        String strQuery = "select ID, ContinentName from Continents";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            ddlContinents.DataSource = cmd.ExecuteReader();
            ddlContinents.DataTextField = "ContinentName";
            ddlContinents.DataValueField = "ID";
            ddlContinents.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
