    namespace TestDatabase
    {
    	public class MyType
    	{
    		public float X;
    		public float Y;
    	};
    
    	public class TestCompositeType
    	{
    		public void Test()
    		{
    			NpgsqlConnection.MapCompositeGlobally&LT;TestDatabase.MyType&GT;( "MySchema.MyType".ToLower() );
    
    			var connection = new NpgsqlConnection( "Host=localhost;Username=postgres;Password=123456;database=testdb".ToLower() );
    			if( null == connection )
    				throw new NullReferenceException( "connection" );
    			try
    			{
    				connection.Open();
    
    				var cmd = new NpgsqlCommand( "MySchema.SetMyType".ToLower(), connection );
    				cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    				var par = new NpgsqlParameter( "ItemID2".ToLower(), NpgsqlDbType.Integer );
    				par.Value = 1;
    				cmd.Parameters.Add( par );
    
    				par = new NpgsqlParameter( "MyType2".ToLower(), NpgsqlDbType.Composite );
    				MyType myType = new MyType();
    				myType.X = 1;
    				myType.Y = 2;
    				par.Value = myType;
    				par.SpecificType = typeof( MyType );
    				cmd.Parameters.Add( par );
    
    				int id = Convert.ToInt32( cmd.ExecuteScalar() );
    			}
    			finally
    			{
    				connection.Close();
    			}
    		}
    	}
    }
