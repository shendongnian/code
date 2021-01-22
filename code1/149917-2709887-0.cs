    using(SqlConnection conn1 = new SqlConnection(DAL.getConnectionStr()))
    {
       using(SqlCommand cmd1 = new SqlCommand("SProc_Item_GetByID", conn1))
       {
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@ID", itemId);
            
            conn1.Open();
   
            cmd1.ExecuteNonQuery();
 
            conn.Close();
       }
    }
