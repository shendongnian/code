           using System.Web.Mvc;
    
           using Microsoft.Azure;
    
           using Microsoft.WindowsAzure.Storage;
    
           using Microsoft.WindowsAzure.Storage.Table; 
    
            public ActionResult Contact()
            {
                //define the emails to output in web page
                string emails = "";
    
                // Retrieve the storage account from the connection string.
    
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    
                    CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
                // Create the table client.
    
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                // Create the CloudTable object that represents the "people" table.
    
                CloudTable table = tableClient.GetTableReference("people");
    
                TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>();
    
                foreach (CustomerEntity entity in table.ExecuteQuery(query))
                {
                        
                        emails += entity.Email+";";
    
                }
    
                ViewBag.Message = "Your contact page."+emails;
    
                return View();
            }
