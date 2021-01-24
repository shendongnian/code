    public async Task<string> ImportSalesOrder(string jsonString)
    {
    	var binding = new BasicHttpsBinding();
    	binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    	
    	var endpoint = new EndpointAddress(_appConfig["endpoint"]);
    
    	var client = new eCommIntegrationMgt_PortClient(binding, endpoint);
    
    	client.ClientCredentials.UserName.UserName = _appConfig["usernam"];
    	client.ClientCredentials.UserName.Password = _appConfig["password"];
    
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
