    MemoryStream memStream = new MemoryStream( );
    Image.FromFile(fileName).Save(memStream, System.Drawing.Imaging.ImageFormat.Bmp);
    
    SqlCommand sqlCmd = new SqlCommand("INSERT INTO TableName(VarBinaryColumn) VALUES (@VarBinary)", sqlConnection);
    sqlCmd.Parameters.Add("@VarBinary", SqlDbType.VarBinary);
    
    sqlCmd.Parameters["@VarBinary"].Value = memStream.GetBuffer();
    
    sqlCmd.ExecuteNonQuery();
