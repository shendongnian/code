    public class TokenProviderController
    {
        private readonly IOptions<TokenProviderOptions> _options;
    
        public TokenProviderController(IOptions<TokenProviderOptions> options)
        {
            _options = options;
        }
    }
