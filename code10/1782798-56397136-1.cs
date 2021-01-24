    public async Task<string> AddNAVSalesOrder(string jsonString)
    {
    	var binding = new BasicHttpsBinding();
    	binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    	
    	var endpoint = new EndpointAddress(_appConfig["NAVEndpoint"]);
    
    	var client = new eCommIntegrationMgt_PortClient(binding, endpoint);
    
    	client.ClientCredentials.UserName.UserName = _appConfig["NAVUsername"];
    	client.ClientCredentials.UserName.Password = _appConfig["NAVPassword"];
    
    	try
    	{
    		var result = await client.ImportSalesOrderAsync(jsonString);
    
    		return result.return_value;
    	}
    	catch (Exception)
    	{
    		throw;
    	}
    }
