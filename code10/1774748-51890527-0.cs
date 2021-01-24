    		public static void Main()
    		{
    			// I know this is marked as obsolete, and I am open to suggestions for alternatives.
    			// see https://github.com/StackExchange/Dapper/issues/798
    #pragma warning disable 618
    			var oldValue = SqlMapper.LookupDbType(typeof(DateTime), null, false, out var handler);
    #pragma warning restore 618
    
    			PerformDapperQuery();
    			SqlMapper.AddTypeMap(typeof(DateTime), DbType.DateTime2);
    			SqlMapper.PurgeQueryCache();
    			PerformDapperQuery();
    			SqlMapper.AddTypeMap(typeof(DateTime), DbType.DateTime);
    			SqlMapper.PurgeQueryCache();
    			PerformDapperQuery();
    			SqlMapper.AddTypeMap(typeof(DateTime), oldValue);
    			SqlMapper.PurgeQueryCache();
    			PerformDapperQuery();
    		}
