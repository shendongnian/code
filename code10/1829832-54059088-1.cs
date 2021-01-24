           [Inject]
            protected LocalStorage localStorage;
           // Note: LocalStorage is a library for storing data in       // the LocalStorage API. You may store your token in the LocalStorage, and retrieve it when you need to verify whether a user is authenticated. 
         
            // This method may be called from your NavMenu Component
            public bool IsAuthenticated()
            {
                var token = localStorage.GetItem<string>("token");
    
                return (token != null); 
            }
           
   
         public async Task<bool> LoginAsync(LoginViewModel model)
    {
        try
        {
            var response = await _http.PostJsonAsync<TokenResult>("/api/auth", model);
            Token = response.Token;
            
             if (Token)
           {
            
              // Save the JWT token in the LocalStorage
              // https://github.com/BlazorExtensions/Storage
              await localStorage.SetItem<Object>("token", Token);
              // Returns true to indicate the user has been logged // in and the JWT token is saved on the user browser
             return true;
           }
        }
        catch (Exception)
        {
            return false;
        }
    }
