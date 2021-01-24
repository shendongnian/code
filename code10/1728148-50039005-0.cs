    private static void Main()
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
        CloudTable table = tableClient.GetTableReference("people");
    
        CustomerEntity customer1 = new CustomerEntity("Harp1", "Walter1");
              
        DateTime accMonth = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1);
        string formatted = accMonth.ToLongTimeString();
        double hour = DateTime.Now.Hour;
        customer1.date = Convert.ToDateTime(formatted).AddHours(-hour+1);
    
        TableOperation insertOperation = TableOperation.Insert(customer1);
    
        table.Execute(insertOperation);
    }
    
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }
    
        public CustomerEntity() { }
    
        public DateTime date { get; set; }
    }
