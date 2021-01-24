    int RowsDeleted = -1;
    using (SqlConnection sqlcon = new SqlConnection(GlobalClass.DBLocate)) {
        string query = "DELETE from [Plans] WHERE Date < GetDate()";
	    SqlCommand cmd = new SqlCommand(query, sqlcon);
	    sqlcon.Open();
        RowsDeleted = cmd.ExecuteNonQuery();
        sqlcon.Close();
    }
