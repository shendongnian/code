    string delimiter = "";
    var writeUnEditedData = new StringBuilder();        
    foreach (int s in connectionData)
    {
        writeUnEditedData.Append(delimiter).Append(s);
        delimiter = ",";
    }
