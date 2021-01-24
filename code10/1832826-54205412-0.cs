c#
        private async Task<IInputClient> GetClientAsync(string secretId)
        {
            HttpClient httpClient = this.httpClientFactory.CreateClient();
            string secret = await this.secretsProvider.GetSecretAsync(secretId);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Concat(":", secret))));
            return this.scope.Resolve<IInputClient>(new TypedParameter(typeof(HttpClient), httpClient));
        }
