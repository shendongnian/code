     using (var db = new DAL.CrawlerDalEntities())
            {
                db.Connection.Open();
                using (var cmd = db.Connection.CreateCommand())
                {
                    cmd.CommandTimeout = storedProcedureDefaultTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CrawlerDalEntities.PerformBackup";
                    cmd.Parameters.Add(new EntityParameter
                    {
                        ParameterName = "fileName",
                        Value = fileName,
                        DbType = DbType.String
                    });
                    cmd.Parameters.Add(new EntityParameter
                    {
                        ParameterName = "backupName",
                        Value = backupName,
                        DbType = DbType.String
                    });
                    cmd.ExecuteNonQuery();
                }
                db.Connection.Close();
            }
