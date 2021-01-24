    [FunctionName("UniquePermissionsReporting")]                                                                     
    public static async Task Run(
    [ServiceBusTrigger("spo-governance-report-permissions", AccessRights.Manage, Connection = "UniquePermisionsQueueConnStr")]string myQueueItem,
    Binder binder,
    TraceWriter log)
        {
            string blobName = "test.csv";
            var attributes = new Attribute[]
            {
                new BlobAttribute($"unique-permission-reports/{blobName}", FileAccess.Write),
                new StorageAccountAttribute("BlobStorageConnStr")
            };
            using (var writer = await binder.BindAsync<TextWriter>(attributes))
            {
                await writer.WriteAsync("Content");
            }
        }
