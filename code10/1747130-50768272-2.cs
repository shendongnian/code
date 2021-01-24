    string separator = ";";
    int pos = 0;
    string format = "";
    // Prepare the format mask for the whole records
    foreach (string headerName in headerColumnMapping)
    {
    	format += "\"{" + pos  + "}\"" + separator;
    	pos++;
    }
    // Remove the last separator and add a newline
    format = format.Substring(0, format.Length - 1) + "\r\n";
    // Create the array of the field positions
    var range = Enumerable.Range(0, reader.FieldCount);
    // Set an initial capacity for the string builder to 10MB
    // Of course this could be a waste of memory if you plan to retrieve
    // small amounts of data.
    StringBuilder csvString = new StringBuilder(1024*1024*10);
    while (dataReader.Read())
    {
    	var x = dataReader as IDataRecord;
        // Create the array of the field values
    	var k = range.Select(r => x[r].ToString()).ToArray();
        // Append the whole line
    	csvString.AppendFormat(format, k);	
    }
