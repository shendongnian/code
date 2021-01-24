     protected async void Page_Load(object sender, EventArgs e)
                {
        
                    if (Request["code"] != null && Session["credential"] ==null)
                    {
                        var result = await getTokenResponse(Request["code"].ToString()); // here we get the code posted by google
        
                    }
        
                }
    private static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailModify };
            async Task<TokenResponse> getTokenResponse(String Code)
            {
                Code = Code.Replace("#", "");
                string redirectUri = WebConfigurationManager.AppSettings["RedirectUrl"].ToString();
                var init2 = new GoogleAuthorizationCodeFlow.Initializer();
                ClientSecrets cli = new ClientSecrets(); 
                cli.ClientId = WebConfigurationManager.AppSettings["ClientID"].ToString(); // init the Client_ID
                cli.ClientSecret = "ClientSecret"; // init the Client_Secret
                init2.ClientSecrets = cli;
                init2.Scopes = Scopes;
                init2.DataStore = null; // you dont need to store token cause we w'll store it in Session object
                GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(init2); /// init the flow wich w'll get the token object 
                CancellationToken cancellationToken = default(CancellationToken);
                var token = await flow.ExchangeCodeForTokenAsync("me", Code, redirectUri, cancellationToken); 
                Response.Write(token);
    
                UserCredential credential = new UserCredential(flow, "me", token); // and know we have the credential 
                Session["credential"] = credential;
                return token;
            }
