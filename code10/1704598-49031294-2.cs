    using (var reader = new XmlTextReader( /* your inputstream */ ))
    {
    	// Buffer for the element contents
    	StringBuilder sb = new StringBuilder(1000);
    	
    	// Read till next node
    	while (reader.Read())
    	{
    		switch (reader.NodeType)
    		{
    			case XmlNodeType.Element: 
					// Clear the stringbuilder when we start with our element 
    				if (string.Equals(reader.Name, "specialelement"))
    				{
    					sb.Clear();
    				}
    				
    				// Append current element without namespace
    				sb.Append("<").Append(reader.Name).Append(">");
    				break;
    			
    			case XmlNodeType.Text: //Display the text in each element.
    				sb.Append(reader.Value);
    				break;
    			
    			case XmlNodeType.EndElement: 
    				
    				// Append the closure element
    				sb.Append("</").Append(reader.Name).Append(">");
    				
    				// Check if we have finished reading our element
    				if (string.Equals(reader.Name, "specialelement"))
    				{
    					// The stringbuilder now contains the entire 'SpecialElement' part
    					using (TextReader textReader = new StringReader(sb.ToString()))
    					{
    						// Deserialize
    						var deserializedElement = (ExampleClass)serializer.Deserialize(textReader);
    						// Send to handler
    						HandleElement(deserializedElement);
    					}
    				}
    
    				break;
    		}
    	}
    }
