    // Assumes that connection is a valid SqlConnection object.
    
    SqlDataAdapter custAdapter = new SqlDataAdapter(
      "SELECT CustomerID, CompanyName FROM Customers", connection);
    
    // Add handlers.
    
    custAdapter.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
    custAdapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
    
    // Set DataAdapter command properties, fill DataSet, modify DataSet.
    
    
    custAdapter.Update(custDS, "Customers");
    
    // Remove handlers.
    
    custAdapter.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
    custAdapter.RowUpdated -= new SqlRowUpdatedEventHandler(OnRowUpdated);
    
    protected static void OnRowUpdating(
      object sender, SqlRowUpdatingEventArgs args)
    {
      if (args.StatementType == StatementType.Delete)
      {
        System.IO.TextWriter tw = System.IO.File.AppendText("Deletes.log");
        tw.WriteLine(
          "{0}: Customer {1} Deleted.", DateTime.Now, 
           args.Row["CustomerID", DataRowVersion.Original]);
        tw.Close();
      }
    }
    
    protected static void OnRowUpdated(
      object sender, SqlRowUpdatedEventArgs args)
    {
      if (args.Status == UpdateStatus.ErrorsOccurred)
      {
        args.Row.RowError = args.Errors.Message;
    
        args.Status = UpdateStatus.SkipCurrentRow;
      }
    }
