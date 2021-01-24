    public class TenantEntityModel : TableEntity
    {
        public string SASReadToken { get; set; }
        public Guid ApiKey { get; set; }
        public TenantEntityModel(string TenantDomainName, string Id, string SASReadToken, Guid ApiKey)
        {
            this.PartitionKey = TenantDomainName;
            this.RowKey = Id;
            this.SASReadToken = SASReadToken;
            this.ApiKey = ApiKey;
        }
    
        public TenantEntityModel() { }
    }
