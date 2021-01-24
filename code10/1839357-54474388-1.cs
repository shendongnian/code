[FunctionName("WebrootConnector")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "customersDB",
                collectionName: "customers",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "999"
            )]
                Customers customersObject, // in binding
            [CosmosDB(
                databaseName: "customersDB",
                collectionName: "customers",
                CreateIfNotExists = true,
                ConnectionStringSetting = "CosmosDBConnection"
            )]
                out Customers customersDocumentToDB, // out binding
                ILogger log)
        {
            if (customersObject == null)
            {
                // Create a new Customers object
                customersObject = new Customers();
                // Set the id of the database document (should always be the same)
                customersObject.Id = "999";
                // Create a new empty customer list on the customers object
                customersObject.customers = new List<Customer>();
            } 
            else
            {
                // if a object is received from the database
                // do something with it.
            }
            if (customersObject.customers != null)
            {
                // Write the object back to the cosmosDB collection
                customersDocumentToDB = customersObject;
                log.LogInformation($"Data written to customerDB");
            }
            else
            {
                customersDocumentToDB = null;
                log.LogInformation($"Nothing to write to database");
            }
         }
The Customers class:
public class Customers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("lastUpdated")]
        public System.DateTime lastUpdated { get; set; }
        [JsonProperty("customers")]
        public List<Customer> customers { get; set; }
    }
public class Customer
    {
        [JsonProperty("customerId")]
        public int customerID { get; set; }
        [JsonProperty("customerName")]
        public string customerName { get; set; }
        [JsonProperty("customerKeycode")]
        public string customerKeyCode { get; set; }
    }
After adding the bindings, one for input and one for output and changed my customersObject class id parameter to string instead of int, everything was working fine, except that the in binding always returned customersObject = null even though I had a document in the collection with id = "999", that was created by the out binding.
I found that the solution for me, was to delete the collection in my cosmosDB on the Azure portal and add CreateIfNotExists = true to the out binding. This allow the out binding to create the collection without a PartitionKey (which are not possible from the Azure portal through the web interface, as this are required) and then remove the PartitionKey = "/id" from the in binding.
Now everything is working as expected :-)
Maybe I was using the PartitionKey wrong?... 
