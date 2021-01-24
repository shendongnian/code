    public class EmailAdress
    {
        CloudStorageAccount storageAccount;
        CloudTableClient tableClient;
        CloudTable pexperimentsEmailAddresses;
        public EmailAdress()
        {
            storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                "experimentstables", "token"), true);
            // Create the table client.
            tableClient = storageAccount.CreateCloudTableClient();
            // Get a reference to a table named "peopleTable"
            pexperimentsEmailAddresses = tableClient.GetTableReference("experimentsEmailAddresses");
        }
    }
