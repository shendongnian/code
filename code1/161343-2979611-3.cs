    static void InsertSettings(IEnumerable<Entry> settings) {
        using (SqlConnection oConnection = new SqlConnection("Data Source=(local);Initial Catalog=Wip;Integrated Security=True")) {
            oConnection.Open();
            using (SqlTransaction oTransaction = oConnection.BeginTransaction()) {
                using (SqlCommand oCommand = oConnection.CreateCommand()) {
                    oCommand.Transaction = oTransaction;
                    oCommand.CommandType = CommandType.Text;
                    oCommand.CommandText = "INSERT INTO [Setting] ([Key], [Value]) VALUES (@key, @value);";
                    oCommand.Parameters.Add(new SqlParameter("@key", SqlDbType.NChar));
                    oCommand.Parameters.Add(new SqlParameter("@value", SqlDbType.NChar));
                    try {
                        foreach (var oSetting in settings) {
                            oCommand.Parameters["@key"].Value = oSetting.Key;
                            oCommand.Parameters["@value"].Value = oSetting.Value;
                            if (oCommand.ExecuteNonQuery() != 1) {
                                //'handled as needed, 
                                //' but this snippet will throw an exception to force a rollback
                                throw new InvalidProgramException();
                            }
                        }
                        oTransaction.Commit();
                    } catch (Exception) {
                        oTransaction.Rollback();
                        oConnection.Close();
                        throw;
                    }
                }
            }
        }
    }
