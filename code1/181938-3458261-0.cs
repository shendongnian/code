    private byte[] GetMp3Bytes(string connString)
    {
       SqlConnection conn = null;
       SqlCommand cmd = null;
       SqlDataReader reader = null;
       
       using (conn = new SqlConnection(connString))
       {
          conn.Open();
          
          using (cmd = new SqlCommand("SELECT TOP 1 Mp3_File FROM MP3_Table", conn))
          using (reader = cmd.ExecuteReader())
          {
              reader.Read();
              return reader["Mp3_File"] as byte[];
          }
       }
    }
