    public class AzureLog : TableEntity
        {
            public AzureLog()
            {
                var now = DateTime.UtcNow;
                PartitionKey = string.Format("{0:yyyy-MM}", now);
                RowKey = string.Format("{0:dd HH:mm:ss.fff}-{1}", now, Guid.NewGuid());
            }
    
            public string RoleInstance { get; set; }
            public string DeploymentId { get; set; }    
            public string Message { get; set; }
            public string Level { get; set; }
    
        }
