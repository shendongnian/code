    SqlConnection sqlcon = new SqlConnection(GlobalClass.DBLocate);
    sqlcon.Open();
    
    DateTime yesterday = DateTime.Today.AddDays(-1);
    
    string query = "Delete from [Plans] Where Date <= '" + 
    yesterday.ToShortDateString() + "'";
    
    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
    
    sda.SelectCommand.ExecuteNonQuery();
