                SqlConnection connection = new SqlConnection("");
                string query = 
                @" SELECT File FROM FileTable where FileID =" + 125;
                SqlCommand command = new SqlCommand(query, connection);
    
                FileStream stream;
                BinaryWriter writer;
    
                int bufferSize = 100;
                byte[] outByte = new byte[bufferSize];
    
                long retval;
                long startIndex = 0;
    
                string pubID = "";
    
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default);
    
                while (reader.Read())
                {    
                    pubID = reader.GetString(0);
    
                    stream = 
                    new FileStream("abc.docx", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new BinaryWriter(stream);
                    startIndex = 0;
                    retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
    
                    while (retval == bufferSize)
                    {
                        writer.Write(outByte);
                        writer.Flush();
                        startIndex += bufferSize;
                        retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
                    }
                    writer.Write(outByte, 0, (int)retval - 1);
                    writer.Flush();
                    writer.Close();
                    stream.Close();
                } reader.Close();
                connection.Close();
