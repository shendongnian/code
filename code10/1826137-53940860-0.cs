     public static string HashKey = "hometelaccess";
        
        public static string GetValue(string key)
        {
            key = key.ToLower();
            List<KeyValue> lstKeyValue = GetLstKeyValue();
            return lstKeyValue.FirstOrDefault(x => x.Key == key)?.Value.Decrypt(HashKey);
        }
        private static List<KeyValue> GetLstKeyValue()
        {
                List<KeyValue> lstKeyValue = new List<KeyValue>();
                var conectstring = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Application.StartupPath + "/DataString.mdb"};Jet OLEDB:Database Password =123987741963;";
                try
                {
                    using (OleDbConnection conection = new OleDbConnection())
                    {
                        using (OleDbCommand ocm = new OleDbCommand())
                        {
                            conection.ConnectionString = conectstring;
                            conection.Open();
                            ocm.Connection = conection;
                            OleDbDataAdapter command = new OleDbDataAdapter("select * from [Tbl_Config]", conection);
                            System.Data.DataTable dt = new System.Data.DataTable();
                            command.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                lstKeyValue.Add(new KeyValue { Key = row["Key"].ToString(), Value = row["Value"].ToString() });
                            }
                            conection.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                }
                return lstKeyValue;
            }
        public static void SaveToConfig(string key, string value)
        {
            key = key.ToLower();
            if (!File.Exists(filePath))
                File.Create(filePath);
            List<KeyValue> lstKeyValue = GetLstKeyValue();
            var conectstring = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Application.StartupPath + "/Datastring.mdb"};Jet OLEDB:Database Password =123987741963;";
            try
            {
                using (OleDbConnection conection = new OleDbConnection())
                {
                    using (OleDbCommand ocm = new OleDbCommand())
                    {
                        conection.ConnectionString = conectstring;
                        ocm.Connection = conection;
                        conection.Open();
                        KeyValue keyValue = lstKeyValue.FirstOrDefault(x => x.Key == key);
                        if (keyValue == null)
                        {
                           var x= ocm.CommandText = "Insert Into [Tbl_Config] ([Key] , [Value]) VALUES(?,?)";       
                            ocm.Parameters.AddWithValue("key", key);
                            ocm.Parameters.AddWithValue("Value", value.Encrypt(HashKey));
                            
                            ocm.ExecuteNonQuery();
                        }
                        else
                        {
                            ocm.CommandText = "UPDATE [Tbl_Config] SET [Value]=? where [Key]=?";                           
                            ocm.Parameters.Add("@Value", OleDbType.LongVarWChar).Value = value.Encrypt(HashKey);
                            ocm.Parameters.Add("@key", OleDbType.LongVarWChar).Value = key;
                            ocm.ExecuteNonQuery();
                        }
                          
                        conection.Close();
                    }
                }
            }
            catch (Exception e)
            {
            }
            
        }
