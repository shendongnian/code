    var list = new List<Data>();
    	var i=0;
    	using (TextFieldParser parser = new TextFieldParser(filePath))
        {
    		
            parser.Delimiters = new string[] { "," };
            while (true)
            {
            	string[] parts = parser.ReadFields();
    			if(i++==0) 
    				continue;
            	if (parts == null)
    	           	break;
    				
    
    			list.Add
    			(
    				new Data
    				{
    					People = parts[0],
    					Tax = Double.Parse(parts[1]),
    					Company = parts[2]
    				}
    			);
            
            }
        }
