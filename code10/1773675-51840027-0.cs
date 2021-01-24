                using (SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(@"ActualsCreator", sqlConnection))
                    {
                       //define sqlcommandtype as SP
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                       //define induvidual parameters for the SP
                        SqlParameter Param_MeaName = sqlCommand.CreateParameter();
                        Param_MeaName.ParameterName = @"@MeaName";
                        Param_MeaName.SqlDbType = SqlDbType.NVarChar;
                        Param_MeaName.Size = 50;
                        Param_MeaName.Direction = ParameterDirection.Input;
                        Param_MeaName.Value = i.MeaName;
                        
                        //Add the paramters in the sqlcommand
                        sqlCommand.Parameters.Add(Param_Order_Key);
               
                        //Open the connection
                        sqlConnection.Open();
                        //Execute the SP
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
