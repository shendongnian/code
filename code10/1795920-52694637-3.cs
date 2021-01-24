    @using JwtAuthentication.Client.Services
    // ...
    @page "/login"
    // ...
    @inject TokenService tokenService
    
    // ...
    @functions {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Token { get; set; } = "";
    
    
        /// <summary>
        /// response from server
        /// </summary>
        private class TokenResponse{
            public string Token;
        }
    
        private async Task SubmitForm()
        {
            var vm = new TokenViewModel
            {
                Email = Email,
                Password = Password
            };
    
            var response = await Http.PostJsonAsync<TokenResponse>("http://localhost:57778/api/Token", vm);
            await tokenService.SaveAccessToken(response.Token);
        }
    }
