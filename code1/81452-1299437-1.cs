    object yourMysteryObject = (whatever you like it to be);
    MemoryStream memStream = new MemoryStream();
    StreamWriter sw = new StreamWriter(memStm);
    sw.Write(yourMysteryObject);
    
    SqlCommand sqlCmd = new SqlCommand("INSERT INTO TableName(VarBinaryColumn) VALUES (@VarBinary)", sqlConnection);
    sqlCmd.Parameters.Add("@VarBinary", SqlDbType.VarBinary);
    
    sqlCmd.Parameters["@VarBinary"].Value = memStream.GetBuffer();
    
    sqlCmd.ExecuteNonQuery();
