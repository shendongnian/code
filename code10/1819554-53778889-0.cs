                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = sqlcon,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "MyStoredProc"
                    };
                    sqlCommand.Parameters.AddWithValue("@Parameter1", Parameter1);
                   
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception exp)
            {
                LogHelper.LogError(string.Concat("Exception Details: ", ExceptionFormatter.WriteExceptionDetail(exp)));
                throw exp;
            }
            finally
            {
                dt.Dispose();
            }
