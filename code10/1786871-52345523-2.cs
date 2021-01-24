    using (var con = SQLConnection.GetConnection())
    using (var cmd = new SqlCommand(sql, con)) {
        cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = PhotoByte;
        con.Open();
        int count = (int)cmd.ExecuteScalar();
        if (count > 0 ) {
            ...
        }
    }
