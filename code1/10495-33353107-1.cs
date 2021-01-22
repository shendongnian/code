    string constr = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=|DataDirectory|\myData.mdf; Integrated Security=True; Connect Timeout=30;";
    using (SqlConnection conn = new SqlConnection(constr))
    string constr =    ConfigurationManager.ConnectionStrings["myData"].ToString();
                   
    using (SqlConnection conn = new SqlConnection(constr))
    {
    sqlQuery=" Your Query here"
    SqlCommand com = new SqlCommand(sqlQuery, conn);
    com.Connection.Open();
    string strOutput = (string)com.ExecuteScalar();
    }
