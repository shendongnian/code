    public class Statement
    {
        string _satementId;
    	public void ReadFromXml( XmlReader reader )
    	{
    		reader.MoveToContent();
    
    		// Read noe attributes
    		_statementId = reader.GetAttribute( "statementId" );
    		...
    		
    		if( reader.IsEmptyElement ) { reader.Read(); return; }
    		
    		reader.Read();
    		while( ! reader.EOF )
    		{			
    			....same basic loop
    		}		
    	}
    }
