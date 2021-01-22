      public bool updateusertable(string UserName,string Password,string Datetime)
                {
                    bool bResult = false;            
                SqlTransaction tx; 
                    try
                    {
    tx.Begintransaction();
                        SqlCommand Ocmd = new SqlCommand();
                        Sqlconnect = Cconnect.OpenSqlConnection();
                        Ocmd.Connection = Sqlconnect;
                        Ocmd.CommandType = CommandType.StoredProcedure;
                        Ocmd.CommandText = "SP_User_login_Update";
                        Ocmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
                        Ocmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
                        Ocmd.Parameters.Add("@lastlogin", SqlDbType.VarChar, 100).Value = Datetime;
                        int i = Ocmd.ExecuteNonQuery();
                        if (i <= 1)
                        {
                            bResult = true;
                        }else
                        {
                            tx.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message.ToString();
                        tx.Rollback();
                    }
                    finally
                    {
                        tx.Commit();
                    }
                    return bResult;
                }
