    public class MultiCredentialProvider : ICredentialProvider
        {
            private readonly IConfiguration _configuration;
            private readonly Func<Task<List<MultiBotCredential>>> _botCredentialsFunc;
    
            public MultiCredentialProvider(IConfiguration configuration, Func<Task<List<MultiBotCredential>>> botCredentialsFunc)
            {
                _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
                _getBotCredentialsFunc = botCredentialsFunc;
            }
    
            public int BotId => _configuration.GetBotId();
    
            public async Task<bool> IsValidAppIdAsync(string appId)
            {
                var botCredentials = await _botCredentialsFunc.Invoke();
                var credential = botCredentials.FirstOrDefault(x => x.BotId == BotId);
    
                if (credential == null)
                {
                    return false;
                }
    
                return credential.AppId.Equals(appId, StringComparison.InvariantCultureIgnoreCase);
            }
    		
    		...
    	}
