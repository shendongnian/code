    // Get the db connection
    SqlConnection dbCon = new SqlConnection("connection string");
    
    // Select the data from the database table into a DataSet (even if it's empty)
    DataSet myData = new DataSet();
    SqlDataAdapter dbAdapter = new SqlDataAdapter("select * from ProcessData", dbCon);
    dbAdapter.Fill(myData);
    myData.Tables[0].TableName = "ProcessData"; // Keeps the table name consistent for the DataMember property
    
    // Use the command builder to add insert, delete, update commands to your adapter
    // You must have a primary key on the table for these to work, though
    SqlCommandBuilder dbComBuilder = new SqlCommandBuilder(dbAdapter);
    
    dbAdapter.InsertCommand = dbComBuilder.GetInsertCommand();
    dbAdapter.DeleteCommand = dbComBuilder.GetDeleteCommand();
    dbAdapter.UpdateCommand = dbComBuilder.GetUpdateCommand();
    
    // Bind the data set to the GridView for viewing / editing
    yourGridControl.AutoGenerateColumns = true; // Optional, if you haven't manually added the columns
    yourGridControl.DataSource = myData;
    yourGridControl.DataMember = "ProcessData";
    
    // Use the db adapter to update the database (by calling those commands) with 
    // changes made to the DataSet through the grid.  This would go in a different
    // form event, like a Save Button click.
    dbAdapter.Update();
