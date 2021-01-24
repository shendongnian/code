    var graphserviceClient = new GraphServiceClient(
        new DelegateAuthenticationProvider(
            (requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", "<your-access-token>");
                return Task.FromResult(0);
            }));
    		
    Microsoft.Graph.Group group = new Microsoft.Graph.Group();
    group.Description = "Self help community for library";
    group.DisplayName = "Library Assist";
    group.GroupTypes = new List<string> { "Unified" };
    group.MailEnabled = true;
    group.MailNickname = "library";
    group.SecurityEnabled = true;		
    
    var createdGroup = await graphserviceClient.Groups.Request().AddAsync(group);
