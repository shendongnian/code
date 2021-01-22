    public static void createCsvFile(IDataReader reader, StreamWriter writer) {
    	string Delimiter = "\"";
    	string Separator = ",";
	
    	// write header row
    	for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++) {
    		if (columnCounter > 0) {
    			writer.Write(Separator);
    		}
    		writer.Write(Delimiter + reader.GetName(columnCounter) + Delimiter);
    	}
    	writer.WriteLine(string.Empty);
    	// data loop
    	while (reader.Read()) {
    		// column loop
    		for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++) {
    			if (columnCounter > 0) {
    				writer.Write(Separator);
    			}
    			writer.Write(Delimiter + reader.GetValue(columnCounter).ToString().Replace('"', '\'') + Delimiter);
    		}   // end of column loop
    		writer.WriteLine(string.Empty);
    	}   // data loop
    	writer.Flush();
    }
