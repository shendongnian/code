    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
{
    ddlCity.Items.Clear();
    ddlCity.Items.Add(new ListItem("--Select City--", ""));
    ddlCity.AppendDataBoundItems = true;
    String strConnString = ConfigurationManager
               .ConnectionStrings["conString"].ConnectionString;
    String strQuery = "select ID, CityName from Cities " +
                                "where CountryID=@CountryID";
    SqlConnection con = new SqlConnection(strConnString);
    SqlCommand cmd = new SqlCommand();
    cmd.Parameters.AddWithValue("@CountryID",
                          ddlCountry.SelectedItem.Value);
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = strQuery;
    cmd.Connection = con;
    try
    {
        con.Open();
        ddlCity.DataSource = cmd.ExecuteReader();
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "ID";
        ddlCity.DataBind();
        if (ddlCity.Items.Count > 1)
        {
            ddlCity.Enabled = true;
        }
        else
        {
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
