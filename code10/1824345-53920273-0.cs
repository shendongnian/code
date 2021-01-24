     public static int ExecuteNonQuery(string commandText, CommandType commandType, ref List<SqlParameter> parameters)
            {
                int result = 0;
                if (!string.IsNullOrEmpty(commandText))
                {
                    using (var cnn = new SqlConnection(Settings.GetConnectionString()))
                    using (var cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText = commandText;
                        cmd.CommandType = commandType;
                        cmd.CommandTimeout = Convert.ToInt32(Settings.GetAppSetting("CommandTimeout") ?? "3600"); 
                        cmd.Parameters.AddRange(parameters.ToArray());
                        cnn.Open();
                        result = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                return result;
            }
 
