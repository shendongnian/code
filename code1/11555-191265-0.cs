    public class DataProvider
    {
    	protected string _connectionString;
    	public DataProvider( string psConnectionString )
    	{
    		_connectionString = psConnectionString;
    	}
    	public void UseReader( string psSELECT, DataReaderUser readerUser )
    	{
    		using ( SqlConnection connection = new SqlConnection( _connectionString ) )
    		try
    		{
    			SqlCommand command = new SqlCommand( psSELECT, connection );
    			connection.Open();
    			SqlDataReader reader = command.ExecuteReader();
    	
    			while ( reader.Read() )
    				readerUser( reader );  // the delegate is invoked
    		}
    		catch ( System.Exception ex )
    		{
    			// handle exception
    			throw ex;
    		}
    	}
    }
