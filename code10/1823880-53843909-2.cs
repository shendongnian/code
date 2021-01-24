        public class SecondClass
        {
            public static async Task UploadDocToBlobStorage(float version, string filename)
            {
                string storageConnectionString = "";
                CloudStorageAccount storageAccount = Common.GetStorageAccount(storageConnectionString);
    
                string blobUrl = await Common.GetBlobUrl(storageAccount, "tncdata", filename);
    
                CloudTable table = await Common.GetTableAsnyc(storageAccount, "CommonURL");
    
                var v = "v" + version;
                VersionURL content = new VersionURL("TnC", v);
                content.ETag = "*";
                content.URL = blobUrl;
                var query = new TableQuery<VersionURL>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, v));
                TableContinuationToken continuationToken = null;
                do
                {
                    var result = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
                    continuationToken = result.ContinuationToken;
    
                    if (result.Count() != 0)
                    {
                        foreach (VersionURL entity in result)
                        {
                            if (entity.RowKey == v)
                            {
                                try
                                {
    
                                    var dec = version + .1;
                                    content.RowKey = "v" + dec;
                                    TableOperation updateOperation = TableOperation.Insert(content);
                                    await table.ExecuteAsync(updateOperation);
    
    
                                }
                                catch (Exception ex)
                                {
    
                                }
                            }
    
                        }
                    }
                    else
                    {
                        TableOperation insertOperation = TableOperation.Insert(content);
                        await table.ExecuteAsync(insertOperation);
                    }
                } while (continuationToken != null);
    
            }
    
    
            public static string GetURL(float version)
            {
    
                string storageConnectionString = "";
                CloudStorageAccount storageAccount = Common.GetStorageAccount(storageConnectionString);
                CloudTable table = Common.GetTable(storageAccount, "CommonURL");
    
                var v = "v" + version;
                var tableQuery = new TableQuery<VersionURL>();
                tableQuery = new TableQuery<VersionURL>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, v));
                var entities = table.ExecuteQuerySegmentedAsync(tableQuery, null);
                var results = entities.Result;
                var s = "";
                foreach (var file in results.Where(x => x.RowKey == v))
                {
                    //if (file.RowKey == v)
                    //{
                    return s = file.URL;
    
                    //}
                    //else
                    //    return null;
                }
    
                return null;
            }
    
        }
