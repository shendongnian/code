    protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
{
    ddlCountry.Items.Clear();
    ddlCountry.Items.Add(new ListItem("--Select Country--", ""));
    ddlCity.Items.Clear();
    ddlCity.Items.Add(new ListItem("--Select City--", ""));   
 
    ddlCountry.AppendDataBoundItems = true;
    String strConnString = ConfigurationManager
        .ConnectionStrings["conString"].ConnectionString;
    String strQuery = "select ID, CountryName from Countries " +
                       "where ContinentID=@ContinentID";
    SqlConnection con = new SqlConnection(strConnString);
    SqlCommand cmd = new SqlCommand();
    cmd.Parameters.AddWithValue("@ContinentID",
        ddlContinents.SelectedItem.Value); 
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = strQuery;
    cmd.Connection = con;
    try
    {
        con.Open();
        ddlCountry.DataSource = cmd.ExecuteReader();
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "ID";
        ddlCountry.DataBind();
        if (ddlCountry.Items.Count > 1)
        {
            ddlCountry.Enabled = true;
        }
        else
        {
            ddlCountry.Enabled = false;
            ddlCity.Enabled = false;
        }
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
