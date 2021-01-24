    public DataTable GetAssignedRolesForUser(string ConnectionString, string TableName, User userDo)
            {
                //LogManager.EventLog("Inside GetAssignedRolesForUser");
                try
                {
                    DataTable DTT = new DataTable();
                    //See if UserID exists check is required here
                    using (var connection = new DB2Connection(ConnectionString))
                    {
                        //connection.Open(); //open/close connection will be done implicitely by the DataAdapter.
                        using (DB2Command cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = DataBaseObjects.spGetAssignedRoles;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new DB2Parameter(DataBaseObjects.ParamVUserID, DB2Type.Integer)).Value = userDo.User_ID;
                            cmd.Parameters.Add(new DB2Parameter(DataBaseObjects.ParamVBusinessEntityID, DB2Type.Integer)).Value = ConfigurationManager.AppSettings["BusinessEntity"];
                            //cmd.CommandTimeout = CommandTimeout; //wait time before terminating the attempt to execute a command and generating an error in secs
    
                            using (var da = new DB2DataAdapter(cmd))
                            {
                                da.Fill(DTT);
                            }
                            DTT.TableName = TableName;
                            return DTT;
                        }
                    }
                }
                catch (Exception)
                {
                    //LogManager.EventLog("[Error] Inside GetAssignedRolesForUser: " + ex.Message);
                    throw;
                }
            }
