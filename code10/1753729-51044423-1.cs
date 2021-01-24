    bool valueFound = false;
    
    // check if the value exists
    for (int i = 0; i < result.Tables["details"].Rows.Count; i++)
    {
        if (companyname == result.Tables["details"].Rows[i]["Companyname"].ToString())
        {
            // it exists so we exit the loop
            valueFound = true;
            break;
        }
    }
    // we have looped all the way without finding the value, so we can insert
    if(!valueFound)
    {
        string strConn = Convert.ToString(ConfigurationManager.ConnectionStrings["connectionstring"]);
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand(
              "INSERT INTO tblVisitorcompany ([CompanyName], " +
              "[Location1]) " +
              "VALUES(@CompanyName, @Location1)", conn);
         cmd.Parameters.AddWithValue("@Companyname", companyname);
         cmd.Parameters.AddWithValue("@Location1", Location1);
         conn.Open();
         cmd.ExecuteNonQuery();
         conn.Close();
    }
