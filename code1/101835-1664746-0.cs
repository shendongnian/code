    static readonly Dictionary<String, String> types = new Dictionary<String, String>()
    {
    	{ "string", "System.String" },
    	{ "int", "System.Int32" }
    	// etc
    };
    
    private void Execute(String user_type)
    {
        String type;
    
        user_type = (user_type ?? String.Empty);    	
    	if (!types.TryGetValue(user_type.ToLower(), out type))
    	{
    	    type = user_type;
    	}
    }
