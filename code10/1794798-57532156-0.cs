// method call
var t = SendEmailUsingGraphAPI();
t.Wait();
// method
static async Task<Boolean> SendEmailUsingGraphAPI() {
    // AUTHENTICATION
    var tenantID = "YOUR_TENANT_ID"; //azure ad tenant/directory id
    var clientID = "YOUR_APPS_CLIENT_ID"; // registered app clientID
    var scopes = "user.read mail.send";  // DELEGATE permissions that the request will need
    string authority = $"https://login.microsoftonline.com/{tenantID}";
    string[] scopesArr = new string[] { scopes };
    try {
        IPublicClientApplication app = PublicClientApplicationBuilder
                .Create(clientID)
                .WithAuthority(authority)
                .Build();
        var accounts = await app.GetAccountsAsync();
        AuthenticationResult result = null;
        if (accounts.Any()) {
            result = await app.AcquireTokenSilent(scopesArr, accounts.FirstOrDefault())
                .ExecuteAsync();
        }
        else {
            // you could acquire a token by username/password authentication if you aren't federated.
            result = await app.AcquireTokenByIntegratedWindowsAuth(scopesArr)
                //.WithUsername(fromAddress)
                .ExecuteAsync(CancellationToken.None);
        }
        Console.WriteLine(result.Account.Username);
        // SEND EMAIL
        var toAddress = "EMAIL_OF_RECIPIENT";
        var message = "{'message': {'subject': 'Hello from Microsoft Graph API', 'body': {'contentType': 'Text', 'content': 'Hello, World!'}, 'toRecipients': [{'emailAddress': {'address': '" + result.Account.Username + "'} } ]}}";
        var restClient = new RestClient("https://graph.microsoft.com/v1.0/users/" + result.Account.Username + "/sendMail");
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", "Bearer " + result.AccessToken);
        request.AddParameter("", message, ParameterType.RequestBody);
        IRestResponse response = restClient.Execute(request);
        Console.WriteLine(response.Content);
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
        throw e;
    }
    return true;
}
