    var graphserviceClient = new GraphServiceClient(
    	new DelegateAuthenticationProvider(
    		(requestMessage) =>
    		{
    			requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", "<your-access-token>");
    			return Task.FromResult(0);
    		}));
        		
    var group = new Microsoft.Graph.Group
    {
    	DisplayName = "Library Assist",
    	Description = "Self help community for library",
    	MailNickname = "library",
    	MailEnabled = true,
    	SecurityEnabled = true,
    	GroupTypes = new List<string> { "Unified" }
    };		
        
    var createdGroup = await graphserviceClient.Groups.Request().AddAsync(group);
