    void Main()
    {
    	var dic = new Dictionary<string, object>();
    	dic.Add( "Key1", 1 );
    	dic.Add( "Key2", 2 );	
    	
    	MyFunction( dic ).Dump();
    }
    
    public static object MyFunction( IDictionary dic )
    {
       return dic["Key1"];
    }
