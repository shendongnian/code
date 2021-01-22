    //in a function, far far away from any button click handler :P
    foreach(var printer in PrinterUtility.GetDefaultPrinters())
    {
      if (printer.IsOnline())
      {
        var pDoc = new PrintDocument(); //or get from PrintDialog
        pDoc.PrinterSettings.PrinterName = printer["Name"].ToString();
        if (pDoc.PrinterSettings.IsValid) //just check WMI didn't tell fibs about the name
        {
          //do printy things       
        }
      }
    }
