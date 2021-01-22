    var sourceConnectionString = "Data Source=sourceServer;Initial Catalog=MyDB;Integrated Security=True;";
    var destinationConnectionString = "Data Source=destinationServer;Initial Catalog=MyDB;Integrated Security=True;";
    var sourceLocalPath = @"C:\MSSQL\DATA\MyDB.mdf";
    var destinationLocalPath = @"C:\MSSQL\DATA\MyDB.mdf";
    var sourceRemotePath = @"\\ServerNameA\ShareName\MyDB.mdf";
    var destinationRemotePath = @"\\ServerNameB\ShareName\MyDB.mdf";
    // Make connections
    var sourceConnection = new SqlConnection(sourceConnectionString);
    sourceConnection.Open();
    var destinationConnection = new SqlConnection(destinationConnectionString);
    destinationConnection.Open();
    // Detach source database
    var sourceCommand = new SqlCommand("sp_detach_db MyDB", sourceConnection);
    sourceCommand.ExecuteNonQuery();
    // Detach destination database
    var destinationCommand = new SqlCommand("sp_detach_db MyDB", destinationConnection);
    destinationCommand.ExecuteNonQuery();
    // Copy database file
    File.Copy(sourceRemotePath, destinationRemotePath);
    // Re-attach source database
    sourceCommand = new SqlCommand("CREATE DATABASE MyDbName ON (FILENAME = '" + sourceLocalPath + "') FOR ATTACH", sourceConnection);
    sourceCommand.ExecuteNonQuery();
    // Re-attach destination database
    destinationCommand = new SqlCommand("CREATE DATABASE MyDbName ON (FILENAME = '" + destinationLocalPath + "') FOR ATTACH", destinationConnection);
    destinationCommand.ExecuteNonQuery();
