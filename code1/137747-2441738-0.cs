    public class Account
    {
        string _accountId;
        string _nameOfKin;
        Statements _statmentsAvailable;
   
    	public void ReadFromXml( XmlReader reader )
    	{
    		reader.MovToContent();
    
    		// Read node attributes
    		_accountId = reader.GetAttribute( "accountId" );
    		...
    		
    		if( reader.IsEmptyElement ) { reader.Read(); return; }
    		
    		reader.Read();
    		while( ! reader.EOF )
    		{
    			if( reader.IsStartElement() )
    			{
    				switch( reader.Name )
    				{
    					// Read element for a property of this class
    					case "NameOfKin":
    						_nameOfKin = reader.ReadElementContentAsString();
    						break;
    						
    					// Starting sub-list
					case "StatementsAvailable":
						_statementsAvailable = new Statements();
						_statementsAvailable.Read( reader );
						break;
    					default:
    						reader.Skip();
    				}
    			}
    			else
    			{
    				reader.Read();
    				break;
    			}
    		}		
    	}
    }
