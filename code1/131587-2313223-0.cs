    public static SqlCommand ProcessSqlCommand(string strSql, string strConnect, Action<SqlCommand> processingMethod)
    { 
        using (SqlConnection con = new SqlConnection(strConnect)) 
        { 
            con.Open(); 
            SqlCommand cmd = GetSqlCommand(); 
            cmd.Connection = con; 
            cmd.CommandText = strSql; 
            processingMethod(cmd); 
        } 
    } 
