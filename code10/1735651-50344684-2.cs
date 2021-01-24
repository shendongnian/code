    var itemsToAdd= from it in extractedList
                    select new { Date= DateTime.Parse(it.Date), //Or ParseExact
                                 it.Client,
                                 it.Path,
                                 DateAddedToDb = DateTime.Now,
                                 FileName = it.Path.Substring(it.Path.LastIndexOf("/")+1)
                                };
    var fields=new []{"Date", "Client", "Path","DateAddedToDb","FileName"};
    using(var bcp = new SqlBulkCopy(connection)) 
    using(var reader = ObjectReader.Create(itemsToAdd, fields)) 
    { 
       bcp.DestinationTableName = "FileTrckT"; 
       bcp.WriteToServer(reader); 
    }
