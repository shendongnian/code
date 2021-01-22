    static readonly Dictionary<String, String> types = new Dictionary<String, String>()
    {
    	{ "string", "System.String" },
    	{ "sbyte", "System.SByte" },
    	{ "byte", "System.Byte" },
    	{ "short", "System.Int16" },
    	{ "ushort", "System.UInt16" },
    	{ "int", "System.Int32" },
    	{ "uint", "System.UInt32" },
    	{ "long", "System.Int64" },
    	{ "ulong", "System.UInt64" },
    	{ "char", "System.Char" },
    	{ "float", "System.Single" },
    	{ "double", "System.Double" },
    	{ "bool", "System.Boolean" },
    	{ "decimal", "System.Decimal" },
    	{ "void", "System.Void" },
    	{ "object", "System.Object" }
    };
    
    private void Execute(String user_type)
    {
    	String type;
    	if (!types.TryGetValue(user_type, out type))
    	{
    		type = user_type;
    	}
    }
