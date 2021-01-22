    using System.Data;
    
    namespace MyGreatNamespace
    {
    	class MyGreatClass
    	{
    		static public DataTable executeTable( string query )
    		{
    			return executeTable( query, null, null );
    		}
    
    		static public DataTable executeTable( string query, string[] params, object[] values )
    		{
    			using ( SqlConnection connection = new SqlConnection( myConnectionString ) )
    			{
    				DataTable myTable = new DataTable();
    		
    				using( SqlCommand command = new SqlCommand( connection ) )
    				{
    					command.CommandType = CommandType.Text;
    					command.CommandText = myQuery;
    		
    					if ( parameters.Count == values.Count && parameters.Count > 0 )
    					{
    						for( int i = 0; i < parameters.Count; i ++ )
    						{
    							command.addParameterWithValue( parameters[i], values[i] );
    						}
    					}
    		
    					using( SqlDataAdapter adapter = new SqlDataAdapter( command ) )
    					{
    						adapter.Fill( out myTable );
    					}
    				}
    				return myTable;
    			}
    		}
    	}
    }
