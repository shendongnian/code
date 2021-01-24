    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName={your_account_name};AccountKey={your_account_key};EndpointSuffix=core.windows.net");
    
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
    CloudTable table = tableClient.GetTableReference("botdata");
    
    TableQuery<MessageEntity> query = new TableQuery<MessageEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "emulator:user"));
    
    foreach (MessageEntity entity in table.ExecuteQuery(query))
    {
        string mydata = "";
        using (var msi = new MemoryStream(entity.Data))
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }
            mydata = Encoding.UTF8.GetString(mso.ToArray());
        }
    
        object data = JsonConvert.DeserializeObject(mydata);
        //.....
    }
