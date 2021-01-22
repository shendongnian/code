    using (SqlConnection con = new SqlConnection(connectionString))
    {
        byte[] input;
        using (System.IO.Stream filestream = System.IO.File.Open(file, System.IO.FileMode.Open))
        {
            int fileLength = (int)filestream.Length;
            input = new byte[fileLength];
            filestream.Read(input, 0, fileLength);
        }
        const string Sql = "insert into upload values(@contents)";
        con.Open();
        using (System.Data.SqlClient.SqlCommand c = new System.Data.SqlClient.SqlCommand(Sql, con))
        {
            c.Parameters.Add("@contents", System.Data.SqlDbType.Binary);
            c.Parameters["@contents"].Value = input;
            c.ExecuteNonQuery();
        }
        using (SqlCommand comm = new SqlCommand("select contents from upload order by id desc", con))
        {
            using (SqlDataReader reader = comm.ExecuteReader())
            {
                int bufferSize = 32768;
                byte[] outbyte = new byte[bufferSize];
                long retval;
                long startIndex = 0;
                startIndex = 0;
                retval = reader.GetBytes(0, startIndex, outbyte, 0, bufferSize);
                while (retval > 0)
                {
                    System.Web.HttpContext.Current.Response.BinaryWrite(outbyte);
                    startIndex += bufferSize;
                    if (retval == bufferSize)
                    {
                        retval = reader.GetBytes(2, startIndex, outbyte, 0, bufferSize);
                    }
                    else
                    {
                        retval = 0;
                    }
                }
            }
        }
    }
