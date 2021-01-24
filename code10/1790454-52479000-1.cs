    MongoCollection resultsCollection = null; 
    try   
         {   
            resultsCollection = database.GetCollection<results>(your_results_name);   
            Console.WriteLine(resultsCollection.Count().ToString());   
         }   
         catch (Exception ex)   
         {   
            Console.WriteLine("Failed to Get collection from Database");   
            Console.WriteLine("Error :" + ex.Message);   
         }
