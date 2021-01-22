    private static void BulkCopyAccessToSQLServer
            (CommandType commandType, string sql, string destinationTable)
        {
            using (DataTable dt = new DataTable())
            {
                using (OleDbConnection conn = new OleDbConnection(Settings.Default.CurriculumConnectionString))
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    cmd.CommandType = commandType;
                    cmd.Connection.Open();
                    adapter.SelectCommand.CommandTimeout = 240;
                    adapter.Fill(dt);
                    adapter.Dispose();
                }
                using (SqlConnection conn2 = new SqlConnection(Settings.Default.qlsdat_extensionsConnectionString))
                {
                    conn2.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy(conn2))
                    {
                        copy.DestinationTableName = destinationTable;
                        copy.BatchSize = 1000;
                        copy.BulkCopyTimeout = 240;
                        copy.WriteToServer(dt);
                        copy.NotifyAfter = 1000;
                    }
                }
            }
        }
