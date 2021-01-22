    var values = new Hashtable();
    values.Add("a", avalue);
    values.Add("b", bvalue);
    values.Add("c", cvalue);
    ...
    
    
    var sql = StringBuilder();
    var cmd = new SqlCommand();
    
    foreach( var value in values )
    {
    	if (sql.Length == 0)
    	{
    		sql.Append "Insert Table1(columnName)"
    		sql.AppendFormat "\nSelect @" + value.Key	
    		cmd.Parameters.Add(new SqlParameter("@" + value.Key, value.Value));
    	}
    	else
    	{
    		sql.AppendFormat "\nUnion All Select @" + value.Key
    		cmd.Parameters.Add(new SqlParameter("@" + value.Key, value.Value));
    	}
    }
    
    cmd.CommandText = sql.ToString()
    cmd.ExecuteNonQuery();
