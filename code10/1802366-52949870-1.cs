    class SomeService
    {
        private ITokenStore _tokenStore;
    
        public SomeService(ITokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }
        
        public string DoThings(params..)
        {
            var currentToken = _tokenStore.GetCurrentToken();
            if (currentToken == null)
            {
               currentToken = GetNewTokenSomehow();
               _tokenStore.SetCurrentToken(currentToken);          
            }
           
           .... Do other things....
        }
    
    }
       
