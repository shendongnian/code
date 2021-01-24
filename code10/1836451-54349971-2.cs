     public async Task SaveMetaData(string table, DataTable dt)
        {
            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(_configuration.GetConnectionString("DefaultConnection"), SqlBulkCopyOptions.Default))
            { 
                sqlBulk.DestinationTableName = table;
                await sqlBulk.WriteToServerAsync(dt);
            }
        }
