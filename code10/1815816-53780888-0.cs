    /// <summary>
    /// Mock class for CloudTable object
    /// </summary>
    public class MockCloudTable : CloudTable
    {
    
        public MockCloudTable(Uri tableAddress) : base(tableAddress)
        { }
    
        public MockCloudTable(StorageUri tableAddress, StorageCredentials credentials) : base(tableAddress, credentials)
        { }
    
        public MockCloudTable(Uri tableAbsoluteUri, StorageCredentials credentials) : base(tableAbsoluteUri, credentials)
        { }
    
        public async override Task<TableResult> ExecuteAsync(TableOperation operation)
        {
            return await Task.FromResult(new TableResult
            {
                Result = new ScreenSettingEntity() { Settings = "" },
                HttpStatusCode = 200
            });
        }
    }
