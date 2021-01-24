     if (attachmentcsv != null)
     {
      List<string> listmobilenumber = new List<string>();
      string filePath = string.Empty;
      string path = Server.MapPath(@"~/Uploads/");
      filePath = Path.Combine(path, attachmentcsv.FileName);
      IEnumerable<CsvFileModel> allRecords = null;
      StreamReader reader = new StreamReader(filePath);
      using (CsvReader csvReader = new CsvReader(reader))
      {
        csvReader.Configuration.HeaderValidated = null;
        csvReader.Configuration.MissingFieldFound = null;
        allRecords = csvReader.GetRecords<CsvFileModel>().ToArray();
       }
       foreach (var record in allRecords)
       {
         // Passed Mobile number into a list
         listmobilenumber.Add(record.MobileNumber);
       }
     }
