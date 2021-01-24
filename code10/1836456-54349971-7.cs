     public async Task SaveRawData(string table, IEnumerable<LogTagRawDataModel> lrd)
        {
            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(_configuration.GetConnectionString("DefaultConnection"), SqlBulkCopyOptions.Default))
            using (var reader = ObjectReader.Create(lrd, "Id","SerialNumber", "ReadingNumber", "ReadingDate", "ReadingTime", "RunTime", "Temperature", "ProjectGuid", "CombineDateTime"))
            {                
                sqlBulk.DestinationTableName = table;
                await sqlBulk.WriteToServerAsync(reader);
            }  
        }
