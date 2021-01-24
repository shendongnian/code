        protected async Task SubmitForm()
        {
            // Remove any existing Authorization headers
            Http.DefaultRequestHeaders.Remove("Authorization");
            TokenViewModel vm = new TokenViewModel()
            {
                Email = Email,
                Password = Password
            };
            TokenResponse response = await Http.PostJsonAsync<TokenResponse>("api/Token/Login", vm);
            // Now add the token to the Http singleton
            await tokenService.SaveAccessToken(response.Token);
            Http.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0} ", response.Token));
        }
