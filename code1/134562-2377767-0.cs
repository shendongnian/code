    StringBuilder sb = new StringBuilder(); 
    foreach (ListItem item in ddlAge.Items) 
    { 
         if (item.Selected) 
         { 
              string sqlCommand = "SELECT * from TableA WHERE Age IN (@Age)"; 
              SqlConnection sqlCon = new SqlConnection(connectString); 
              SqlCommand sqlComm = new SqlCommand(); 
              sqlComm.Connection = sqlCon; 
              sqlComm.CommandType = System.Data.CommandType.Text; 
              sqlComm.CommandText = sqlCommand; 
              sqlComm.CommandTimeout = 300; 
              sqlComm.Parameters.Add("@Age", SqlDbType.NVarChar);
              sb.Append(item.Text + ","); 
              sqlComm.Parameters["@Age"].Value = sb.ToString().TrimEnd(',');
         } 
    } 
