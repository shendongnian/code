    class Test
    {
    	public int A { get; set;}
    	public string B {get; set;}
    }
    
    class CompositeParameter<T> : SqlMapper.ICustomQueryParameter
    {
    	private readonly T _val;
    	
    	public CompositeParameter(T value) {
    		_val = value;
    	}
    	
    	public void AddParameter(IDbCommand command, string name)
    	{
    		var pgcmd = command as NpgsqlCommand;
    		if(pgcmd == null) throw new ArgumentException("CompositeParameter can only be used with Npgsql connections");
    		
    		pgcmd.Parameters.Add(new NpgsqlParameter() {
    			ParameterName = name,
    			Value = _val,
    			SpecificType = typeof(T),
    			NpgsqlDbType = NpgsqlDbType.Composite
    		});
    	}
    }
