    // Create source connection
    SqlConnection source = new SqlConnection(connectionString);
    // Create destination connection
    SqlConnection destination = new SqlConnection(connectionString);
    
    // Clean up destination table. Your destination database must have the
    // table with schema which you are copying data to.
    // Before executing this code, you must create a table BulkDataTable
    // in your database where you are trying to copy data to.
    
    SqlCommand cmd = new SqlCommand("DELETE FROM BulkDataTable", destination);
    // Open source and destination connections.
    source.Open();
    destination.Open();
    cmd.ExecuteNonQuery();
    // Select data from Products table
    cmd = new SqlCommand("SELECT * FROM Products", source);
    // Execute reader
    SqlDataReader reader = cmd.ExecuteReader();
    // Create SqlBulkCopy
    SqlBulkCopy bulkData = new SqlBulkCopy(destination);
    // Set destination table name
    bulkData.DestinationTableName = "BulkDataTable";
    // Write data
    bulkData.WriteToServer(reader);
    // Close objects
    bulkData.Close();
    destination.Close();
    source.Close();
