    DataTable dt = DBOHelper.GenerateDataTable(dbObjects, out List<string> propertyNames);
            using (SqlBulkCopy sqlBulk = _database.BulkCopySQL())
            {
                sqlBulk.DestinationTableName = table;
                sqlBulk.BatchSize = commitBatchSize;
                foreach (string s in propertyNames)
                {
                    sqlBulk.ColumnMappings.Add(new SqlBulkCopyColumnMapping(s, s));
                }
                try
                {
                    sqlBulk.WriteToServer(dt);
                    dt.Dispose();
                }
                catch (Exception e)
                {
                    AuditEngine.Instance.LogError("DatabaseEngine", "SQLBulkInsert", e.Message);
                    return 0;
                }
            }
