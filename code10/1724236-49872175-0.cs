       // Connecton is IDisposable; we create it 
       //   1. manually - new ...
       //   2. for temporary usage (just for the query)
       using (SqlConnection con = new SqlConnection(objUtilityDAL.ConnectionString)) {
         // Check is redundant here: new instance will be closed 
         con.Open();
         // Command is IDisposable
         using (SqlCommand cmd = con.CreateCommand()) {
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(Parameter);
           cmd.CommandText = _query;
           // Finally, Reader - yes - is IDisposable 
           using (SqlDataReader rdr = cmd.ExecuteReader()) {
             // while (rdr.Read()) {...}
           }
         }   
       }
