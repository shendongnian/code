    DataSet dataSet = new DataSet(); //Create a dataset
    dataSet = _DataEntryDataLayer.ReadResults(); //Call to the dataLayer to return the data
    //LINQ query on a DataTable
    var dataList = dataSet.Tables["DataTable"]
                  .AsEnumerable()
                  .Select(i => new
                  {
                     ID = i["ID"],
                     Name = i["Name"]
                   }).ToList();
