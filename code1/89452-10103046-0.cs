                // Create Instance of Connection and Command Object
                SqlConnection myConnection = new SqlConnection(GentEFONRFFConnection);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("your Procedure Name", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@orgid", SqlDbType.UniqueIdentifier).Value = orgid;
                myCommand.Parameters.Add("@statid", SqlDbType.UniqueIdentifier).Value = statid;
                myCommand.Parameters.Add("@read", SqlDbType.Bit).Value = read;
                myCommand.Parameters.Add("@write", SqlDbType.Bit).Value = write;
                // Mark the Command as a SPROC
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                myConnection.Close();
            
