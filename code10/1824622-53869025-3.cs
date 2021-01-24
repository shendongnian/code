     using (SqlConnection connection = new SqlConnection(connectionstr))
     {
         connection.Open();
         // Delete old entries
         using (SqlTransaction trans = connection.BeginTransaction())
         {
           string sql = "Delete  from PhilaMethod ";
           using (SqlCommand cmd = new SqlCommand(sql, connection, trans))
           {
             cmd.ExecuteNonQuery(); // or whatever method you need
           }
           trans.Commit();
         }
         connection.Close();         
     }
