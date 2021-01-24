    using (SqlConnection connection = new SqlConnection(...))
    {
        using (SqlCommand cmd = new SqlCommand("PP_CreateSheet", connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.Add("@loadSheetNum", SqlDbType.NVarChar);
            ... add all the other parameters, but don't give them a value
            foreach (DataRow dr in dt.Rows)
            {
                cmd.Parameters["@loadSheetNum"].Value = lblSheet.Text; 
                ... set the value to all other parameters
                cmd.ExecuteNonQuery();
            }
        }
      
