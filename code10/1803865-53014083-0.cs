        public bool CheckIfSectetExists(string accessToken, string secretUri)
        {
            var kvClient= new KeyVaultClient(accessToken);
            try
            {
                kvClient.GetSecretAsync(secretUri ).Result.Value;
                return true;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is KeyVaultErrorException exception && exception.Body.Error.Code == "SecretNotFound")
                    return false;
                
                throw;
            }
        }
