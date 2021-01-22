    // Serialize the DataTable to a json string
    string serializedTable = JsonConvert.SerializeObject(myDataTable);    
    Jarray dataRows = Jarray.Parse(serializedTable);
    // Run the LINQ query
    List<JToken> results = (from row in dataRows
                        where (int) row["ans_key"] == 42
                        select row).ToList();
    // If you need the results to be in a DataTable
    string jsonResults = JsonConvert.SerializeObject(results);
    DataTable resultsTable = JsonConvert.DeserializeObject<DataTable>(jsonResults);
