    string graphResourceId = "https://graph.microsoft.com/";
    string authority = "https://login.microsoftonline.com/{0}";
    string tenantId = "tenantId";
    var accessToken = authContext.AcquireTokenAsync(graphResourceId, new ClientCredential(clientId,secret)).Result.AccessToken;
    AuthenticationContext authContext = new AuthenticationContext(authority);
    var graphserviceClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(
                        requestMessage =>
                        {
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
    
                            return Task.FromResult(0);
                        }));
    //get calendars
    var calendars = graphserviceClient.Users["userObjectId"].Calendars.Request().GetAsync().Result
    //new calendar
    var calendar = graphserviceClient.Users["userObjectId"].Calendars.Request().AddAsync(
                new Calendar {
                   Name = "name"
                }).Result
    //new event
    var cal = graphserviceClient.Users["userObjectId"].Events.Request().AddAsync(
                new Event {
                    Subject = "test",
                    Start = new DateTimeTimeZone {DateTime = "2018-11-07T00:56:52.584Z",TimeZone = "UTC" },
                    End = new DateTimeTimeZone { DateTime = "2018-11-07T01:56:52.584Z", TimeZone = "UTC" }
                }).Result;
