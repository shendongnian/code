    public static void BulkInsert<T>(List<ColumnInfo> columnInfo, List<T> data, string 
    destinationTableName, SqlConnection conn = null, string idColumn = "Id")
        {
            NLogger logger = new NLogger();
            var closeConn = false;
            if (conn == null)
            {
                closeConn = true;
                conn = new SqlConnection();
                conn.Open();
            }
            SqlTransaction tran = 
        conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                var options = SqlBulkCopyOptions.KeepIdentity;
                var sbc = new SqlBulkCopy(conn, options, tran);
                var command = new SqlCommand(
                        $"SELECT Max({idColumn}) from {destinationTableName};", conn, 
               tran);
                var id = command.ExecuteScalar();
                int maxId = 0;
                if (id != null && id != DBNull.Value)
                {
                    maxId = Convert.ToInt32(id);
                }
                data.ForEach(d =>
                    {
                        maxId++;
                        d.GetType().GetProperty(idColumn).SetValue(d, maxId);
                    });
                var dt = ConvertToDataTable(columnInfo, data);
                sbc.DestinationTableName = destinationTableName;
                foreach (System.Data.DataColumn dc in dt.Columns)
                {
                    sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                }
                sbc.WriteToServer(dt);
                tran.Commit();
                if(closeConn)
                {
                    conn.Close();
                    conn = null;
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                logger.Write(LogLevel.Error, $@"An error occurred while performing a bulk 
    insert into table {destinationTableName}. The entire
                                               transaction has been rolled back. 
    
    {ex.ToString()}");
                throw ex;
            }
        }
