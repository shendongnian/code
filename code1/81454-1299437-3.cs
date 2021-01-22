    object yourMysteryObject = (whatever you like it to be);
    MemoryStream memStream = new MemoryStream();
    StreamWriter sw = new StreamWriter(memStream); //edited "memStm" to "memStream ".
    sw.Write(yourMysteryObject);
    
    SqlCommand sqlCmd = new SqlCommand("INSERT INTO TableName(VarBinaryColumn) VALUES (@VarBinary)", sqlConnection);
    sqlCmd.Parameters.Add("@VarBinary", SqlDbType.VarBinary, Int32.MaxValue);
    
    sqlCmd.Parameters["@VarBinary"].Value = memStream.GetBuffer();
    
    sqlCmd.ExecuteNonQuery();
