    var datatable = dataset.Tables[0];
    using(var proc = connection.CreateCommand(...))
    {
        proc.Parameters.Add("@firstcolumnname", SqlDbType.Int);
        foreach(DataRow dr in datatable.Rows)
        {
            /* check for DbNull.Value if source column is nullable! */
            proc.Parameters["@firstcolumnname"].Value = dr["FirstColumnName"];
            
            proc.ExecuteNonQuery();
        }
    }
