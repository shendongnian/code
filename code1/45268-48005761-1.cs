    GetOutputParaByCommand("IsEmailExists")
    
    public int GetOutputParaByCommand(string Command)
            {
                object identity = 0;
                try
                {
                    mobj_SqlCommand.CommandText = Command;
                    SqlParameter SQP = new SqlParameter("returnVal", SqlDbType.Int);
                    SQP.Direction = ParameterDirection.ReturnValue;
                    mobj_SqlCommand.Parameters.Add(SQP);
                    mobj_SqlCommand.Connection = mobj_SqlConnection;
                    mobj_SqlCommand.ExecuteScalar();
                    identity = Convert.ToInt32(SQP.Value);
                    CloseConnection();
                }
                catch (Exception ex)
                {
    
                    CloseConnection();
                }
                return Convert.ToInt32(identity);
            }
	
