    IEnumerable<string[]> ReadDataLines(string csv) {	
    	using(var reader = new StringReader(csv))
    	using(var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(reader)) {
    		parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
    		parser.SetDelimiters(",");
    		
    		// Until we find the header row, just throw away all the rows
    		while(!parser.EndOfData) {
    			var line = parser.ReadLine();
    			if(line != null && line.TrimStart().StartsWith("name")) {
    				break;
    			}
    		}		
    		// The rest of the input is data rows
    		while(!parser.EndOfData) {
    			yield return parser.ReadFields();
    		}		
    	}
    }
