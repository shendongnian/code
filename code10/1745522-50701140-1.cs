            //an entity to return
            AltPedVendaModel ret = new AltPedVendaModel();
			var conn = DbContext.Database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    string query = $"select * from .......";
                    command.CommandText = query;
                    DbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //read line to line	
                            ret = new AltPedVendaModel
                            {
                                IsOk = reader.GetBoolean(0),
                                Awb = reader.GetString(1),
                                Invoice = reader.GetString(2),
                                Po = reader.GetString(3),
                                Obs = reader.GetString(4),
                                Frete = reader.GetDecimal(5),
                            };
						
                        }
                    }
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return ret;
