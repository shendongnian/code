    using(SqlConnection con...)
    {
        con.Open();
        using(SqlCommand cmd = new SqlCommand("UPDATE YOURTABLE SET @ColumnName =  @ColumnValue where PrimaryKeyColumn = @PrimaryKey", con);
        {
            cmd.Parameters.Add("@ColumnName");
            cmd.Parameters.Add("@ColumnValue");
            cmd.Parameters.Add("@PrimaryKey");
            foreach(ChangedData cd in changedData)
            {
                cmd.Parameters["@ColumnName"].Value = cd.columnName.ToString();
                cmd.Parameters["@ColumnValue"].Value = cd.columnValue.ToString();
                cmd.Parameters["@PrimaryKey"].Value = cd.primaryKey.ToString();
                cmd.ExecuteNonQuery();
            }
        }
        con.Close();
    }
