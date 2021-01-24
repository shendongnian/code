    public class Auth0Authenticator {
    
        public Auth0Authenticator() { 
            //Subscribe to the event
            autoAuthenticate +=  onAutoAuthenticating(); 
            //raise event to allow async operation.
            autoAuthenticate(this, EventArgs.Empty);
        }
    
        private event EventHandler autoAuthenticate = delegate { };
        private async void onAutoAuthenticating(object sender, EventArgs args) {
            await PerformAuthenticationAsync();
        }
    
        public async Task PerformAuthenticationAsync() {
            Auth0Client auth0Client = new Auth0Client(new Auth0ClientOptions() {
                Domain = "mydomain",
                ClientId = "clientid",
            });
    
            var extraParameters = new Dictionary<string, string>();
            extraParameters.Add("connection", "parameter");
    
            var result = await auth0Client.LoginAsync(extraParameters: extraParameters);
    
            //...do something with the result as needed
            string access_token = result.AccessToken;
            string refresh_token = result.RefreshToken;
            //...
        }
    }
