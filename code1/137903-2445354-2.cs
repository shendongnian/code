    public void SaveFileToDB(string description, byte[] file)
    {
        using (SqlConnection con = new SqlConnection(conStr)
        {
            con.Open();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, description);
                cmd.Parameters.Add("@File", SqlDbType.VarBinary, file);
                cmd.CommandText = "UploadedFileUpdate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
