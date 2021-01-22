     public class WSClientConfig
     {
        public string endpoint = "";
        public string username = "";
        public string password = "";
        public PurgeFilesServiceWse service;
        #region Constructor
	public LLClientConfig(string endpoint, string username, string password)
	{
	      if (endpoint == null || username == null || password == null) 
	      {
		Console.WriteLine("Usage: ENDPOINT, USERNAME, PASSWORD");
                  Console.WriteLine("One of these usage items was NULL!");
		return ;
	      }
            this.endpoint = endpoint;
            this.username = username;
            this.password = password;
	   CreateService();
        }
        #endregion
        #region Class Methods
        /// <summary>
        /// Create the connection to the web service.
        /// </summary>
        protected void CreateService()
        {
            UsernameToken token = new UsernameToken(username, password,   PasswordOption.SendHashed);
            service = new PurgeFilesServiceWse();
            service.Url = endpoint;
            // Create a new policy.
            Policy webServiceClientPolicy = new Policy();
            // Specify that the policy uses the UsernameOverTransportAssertion turnkey security assertion.
            webServiceClientPolicy.Assertions.Add(new UsernameOverTransportAssertion());
            // Apply the policy to the SOAP message exchange.
            service.SetPolicy(webServiceClientPolicy);
            service.SetClientCredential(token);
        }
        #endregion
    }
