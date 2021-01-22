    public class Statements
    {
        List<Statement> _statements = new List<Statement>();
    	public void ReadFromXml( XmlReader reader )
    	{
    		reader.MoveToContent();
    		if( reader.IsEmptyElement ) { reader.Read(); return; }
    		
    		reader.Read();
    		while( ! reader.EOF )
    		{
    			if( reader.IsStartElement() )
    			{
    				if( reader.Name == "Statement" )
    				{
    					var statement = new Statement();
    					statement.ReadFromXml( reader );
    					_statements.Add( statement );				
    				}
    				else
    				{
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
    
