    SqlConnection conn = new SqlConnection(yourConnectionString);
    
    SqlCommand cmd = null;
    SqlParameter param = null;
    
    cmd = new SqlCommand("INSERT INTO MP3 SET DATA = @BLOBPARAM WHERE
    'some criteria'", conn);
    
    FileStream fs = null;
    fs = new FileStream("your mp3 file", FileMode.Open, FileAccess.Read);
    Byte[] blob = new Byte[fs.Length];
    fs.Read(blob, 0, blob.Length);
    fs.Close();
    
    param = new SqlParameter("@BLOBPARAM", SqlDbType.VarBinary, blob.Length,
    ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, blob);
    cmd.Parameters.Add(param);
    conn.Open();
    cmd.ExecuteNonQuery();
