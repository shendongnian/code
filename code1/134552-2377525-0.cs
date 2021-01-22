    string sqlCommand = "SELECT * from TableA WHERE Age IN (@Age)";
    SqlConnection sqlCon = new SqlConnection(connectString);
    SqlCommand sqlComm = new SqlCommand();
    sqlComm.Connection = sqlCon;
    sqlComm.CommandType = System.Data.CommandType.Text;
    sqlComm.CommandText = sqlCommand;
    sqlComm.CommandTimeout = 300;
    
    StringBuilder sb = new StringBuilder();
    foreach (ListItem item in ddlAge.Items)
    {
         if (item.Selected)
         {
             sb.Append(item.Text + ",");
         }
    }
    
    sqlComm.Parameters.AddWithValue("@Age", sb.ToString().TrimEnd(','));
    // OR
    // sqlComm.Parameters.Add(new SqlParameter("@Age", sb.ToString().TrimEnd(',')) { SqlDbType = SqlDbType. NVarChar });
