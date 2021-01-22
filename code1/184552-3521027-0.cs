    SqlConnection conn = new SqlConnection("Data Source=DDPRO8-WIN7X86\\SQLEXPRESS;Initial Catalog=mp3bytes;Persist Security Info=True;Integrated security=true; User ID=; Password=;");
    SqlCommand cmd = null;
    SqlParameter param = null;
    cmd = new SqlCommand(" INSERT INTO mp3_bytes (songs) " + " Values (@songs) ", conn);
   
    param = new SqlParameter("@songs", SqlDbType.VarBinary, fileUpload.FileBytes.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, fileUpload.FileBytes);
    cmd.Parameters.Add(param);
    conn.Open();
    cmd.ExecuteNonQuery();
    conn.Close();
