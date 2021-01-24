    public static class QueueTriggerTableOutput
    {
        [FunctionName("QueueTriggerTableOutput")]
        [return: Table("outTable", Connection = "MY_TABLE_STORAGE_ACCT_APP_SETTING")]
        public static Person Run(
            [QueueTrigger("myqueue-items", Connection = "MY_STORAGE_ACCT_APP_SETTING")]JObject order,
            ILogger log)
        {
            return new Person() {
                    PartitionKey = "Orders",
                    RowKey = Guid.NewGuid().ToString(),
                    Name = order["Name"].ToString(),
                    MobileNumber = order["MobileNumber"].ToString() };
        }
    }
    public class Person
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
    }
