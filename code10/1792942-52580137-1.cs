    public class AzureTableConnection: IAzureTableConnection {
        private readonly CloudTableClient tableClient;
    
        public AzureTableConn(CloudTableClient tableClient) {
            this.tableClient = tableClient;
        }
        
        private CloudTable TableConnection(string tableName) {
            CloudTable cloudTable = tableClient.GetTableReference(tableName);
            return cloudTable;            
        }
        public async Task<HttpResponseMessage> UpdateTenantSettings(TenantSettingsModel tenantSettingsModel) {
            CloudTable cloudTable = TableConnection("TenantSettings");
            var mergeEntity = await cloudTable.ExecuteAsync(TableOperation.Merge(tenantSettingsModel));
            
            //...do something with the result
            
            return new HttpResponseMessage();
        }
    }
    
