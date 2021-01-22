    var sql = StringBuilder();
    
    sql.Append "Insert Table1(a)"
    sql.AppendFormat "\nSelect @a"
    sql.AppendFormat "\nUnion All Select @b"
    sql.AppendFormat "\nUnion All Select @b"
    sql.AppendFormat "\nUnion All Select @c"
    ...
    
    // Set your paramters values
    var cmd = new SqlCommand( sql.ToString() );
    SqlCommand.Parameters.Add(new SqlParameter("@b", aValue));
    SqlCommand.Parameters.Add(new SqlParameter("@b", bValue));
    SqlCommand.Parameters.Add(new SqlParameter("@c", cValue));
    ...
    
    cmd.ExecuteNonQuery();
