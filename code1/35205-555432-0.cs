    static void Main(string[] args)
    {
    	char[] password = new char[] {'p','a','s','s','w','o','r','d'};
    
    	using(StreamReader reader = new StreamReader(@"C:\OpenSSL\bin\CatchEffort.pfx"))
    	{
    		Pkcs12Store store = new Pkcs12Store(reader.BaseStream,password);
    		foreach (string n in store.Aliases)
    		{
    			if(store.IsKeyEntry(n))
    			{
    				AsymmetricKeyEntry key = store.GetKey(n);
    				
    				if(key.Key.IsPrivate)
    				{
    					RsaPrivateCrtKeyParameters parameters = key.Key as RsaPrivateCrtKeyParameters;
    					Console.WriteLine(parameters.PublicExponent);
    				}						
    			}
    		}
    	}
    }
