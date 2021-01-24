    try
            {
                response = await httpClient.PostAsync(proxySettingsConfiguration.RequestUri, encodedContent);
            }
            catch (Exception ex)
            {//In my case I was looking at this error
                if (ex.GetType().ToString() == "Google.Apis.Auth.OAuth2.Responses.TokenResponseException")
                {
                    MessageBox.Show("Failed to login", "Error on login",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Failed to login", "Error on login",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
