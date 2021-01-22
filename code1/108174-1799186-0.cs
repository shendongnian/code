    SqlConnection cn = new SqlConnection("<ConnectionString>");
    cn.Open();
    
    SqlCommand Cmd = new SqlCommand("<StoredProcedureName>", cn);
    Cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
    
    while ( dr.Read() ) {
        // populate your first object
    }
    
    dr.NextResult();
    
    while ( dr.Read() ) {
        // populate your second object
    }
    dr.Close();
