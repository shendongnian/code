    ComReference<StreamClass> LoadTextFromDBToADODBStream(int idParameter,
        string parameterName, string sqlString, ref int size)
    {
        int bytesReturned;
        int chunkSize = 65536;
        int offSet = 0;
    
        // Create the command.
        using (SqlCommand cmd = new SqlCommand())
        {
            // Set the parameters.
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlString;
    
            // See (1).
            using (SqlConnection connection = CreateConnection())
            {
                // Set the connection on the command.
                cmd.Connection = connection;
    
                // Create the parameter and add to the parameters.
                SqlParameter cmdParameter = new SqlParameter(
                    parameterName, idParameter);
                cmd.Parameters.Add(cmdParameter);
    
                // Create the reader.
                using (SqlDataReader dr = cmd.ExecuteReader(
                    CommandBehavior.SequentialAccess))
                {
                    dr.Read();
    
                    // See (2)
                    if (!dr.HasRows)
                    {
                        // Return an empty instance.
                        return new ComReference<StreamClass>();
                    }
    
                    // Create the stream here.  See (3)
                    using (ComReference<StreamClass> adoStreamClass =
                        ComReference<StreamClass>.Create())
                    {
                        // Get the stream.
                        StreamClass adoStream = adoStreamClass.Reference;
    
                        // Open the stream.
                        adoStream.Type = StreamTypeEnum.adTypeText;
                        adoStream.Open(Type.Missing, 
                            ConnectModeEnum.adModeUnknown,
                            StreamOpenOptionsEnum.adOpenStreamUnspecified, 
                            "", "");
    
                        // Create the byte array.
                        byte[] byteChunk = new byte[chunkSize];
    
                        // See (4)
                        Encoding readBytes = Encoding.Unicode;
    
                        // Cycle.
                        do
                        {
                            bytesReturned = (int)dr.GetBytes(0, offSet, 
                                byteChunk, 0, chunkSize);
                            size += bytesReturned;
                            if (bytesReturned > 0)
                            {
                                if (bytesReturned < chunkSize)
                                {
                                    Array.Resize(ref byteChunk,
                                        bytesReturned);
                                }
    
                                adoStream.WriteText(
                                    readBytes.GetString(byteChunk),
                                    StreamWriteEnum.stWriteChar);
                                adoStream.Flush();
                            }
    
                            offSet += bytesReturned;
                        } while (bytesReturned == chunkSize);
    
                        // Release the reference and return it.
                        // See (5).
                        return adoStreamClass.Release();
                    }
                }
            }
        }
    }  
  
