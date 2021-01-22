    private static bool Is46Installed()
    {
    	// API changes in 4.6: https://github.com/Microsoft/dotnet/blob/master/releases/net46/dotnet46-api-changes.md
    	return Type.GetType("System.AppContext, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false) != null;
    }
    
    private static bool Is461Installed()
    {
    	// API changes in 4.6.1: https://github.com/Microsoft/dotnet/blob/master/releases/net461/dotnet461-api-changes.md
    	return Type.GetType("System.Data.SqlClient.SqlColumnEncryptionCngProvider, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false) != null;
    }
    
    private static bool Is462Installed()
    {
    	// API changes in 4.6.2: https://github.com/Microsoft/dotnet/blob/master/releases/net462/dotnet462-api-changes.md
    	return Type.GetType("System.Security.Cryptography.AesCng, System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false) != null;
    }
    
    private static bool Is47Installed()
    {
    	// API changes in 4.7: https://github.com/Microsoft/dotnet/blob/master/releases/net47/dotnet47-api-changes.md
    	return Type.GetType("System.Web.Caching.CacheInsertOptions, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false) != null;
    }
