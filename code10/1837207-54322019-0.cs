    var scanObjects = new List<MyCustomObject>();
    foreach (Row row in resResp.ResultSet.Rows)
    {
        var myObject = new MyCustomObject();
        //Dictionary<String, String> scanData = new Dictionary<String, String>();
        for (var i = 0; i < resResp.ResultSet.ResultSetMetadata.ColumnInfo.Count; i++)
        {
            //scanData.Add(resResp.ResultSet.ResultSetMetadata.ColumnInfo[i].Name, row.Data[i].VarCharValue);
            switch( resResp.ResultSet.ResultSetMetadata.ColumnInfo[i].Name )
            {
                case "ExampleId":
                    myObject.ExampleId = row.Data[i].VarCharValue;
                    break;
                case "ExampleValue":
                    myObject.ExampleValue = row.Data[i].VarCharValue;
                    break;
                default:
                    // Unrecognised/unused column
                    break;
            }
        }
        //scanLists.Add(scanData);
        scanObjects.Add(myObject);
    }
    
