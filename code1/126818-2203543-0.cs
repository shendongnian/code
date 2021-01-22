    using (SqlDataReader rdr = cmd.ExecuteReader()) 
    {
        while (rdr.Read())
        {
            object obj = rdr["quantity"];
            if(obj != null)
            {
                string objType = obj.GetType().FullName;
            }
        }
     }
