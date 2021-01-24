    using (SqlConnection destinationConnection = new SqlConnection (connString))
    {
       destinationConnection.Open ();
    
       using (SqlBulkCopy bulkCopy = new SqlBulkCopy (destinationConnection))
       {
           bulkCopy.DestinationTableName = "dbo.temp_report";
    
           try
           {
               // Write from the source to the destination.
               bulkCopy.WriteToServer (yourdatatable);
           }
           catch (Exception ex)
           {
               Console.WriteLine (ex.Message);
           }
           
       }
    }
