        public class FirstClass
        {
            public static async Task UploadFileToBlobStorage(float version, string filename)
            {
                string storageConnectionString = "";
                CloudStorageAccount storageAccount = Common.GetStorageAccount(storageConnectionString);
    
                string blobUrl = await Common.GetBlobUrl(storageAccount, "logodata", filename);
    
                CloudTable table = await Common.GetTableAsnyc(storageAccount, "CommonURL");
    
                var v = "v" + version;
                VersionURL content = new VersionURL("Logo", v);
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
                                    TableOperation updateOperation = TableOperation.Merge(content);
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
        }
