    System.IO.TextWriter tw = System.IO.File.AppendText("Deletes.log");
    tw.WriteLine(
      "{0}: Customer {1} Deleted.", DateTime.Now, 
       args.Row["CustomerID", DataRowVersion.Original]);
    tw.Close();
