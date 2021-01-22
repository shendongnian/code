    //Database connection code...
    cmd.CommandText = "SELECT FileData FROM Files WHERE ID = @ID";
    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1234;
    SqlDataReader sqlRead = cmd.ExecuteReader();
    if (sqlRead.HasRows)
    {
        while(sqlRead.Read())
        {
            byte[] fileData = (byte[]) sqlRead[0].Value;
            //Do what you will with fileData here...
        }
    }
    sqlRead.Close();
