    private void SaveConnectionData(JSON.Connection C)
                        {
                            App.Current.Properties[Cryptography.Encryption("AccessToken")] = Cryptography.Encryption(C.Access_token);
                            App.Current.Properties[Cryptography.Encryption("ExpiresIn")] = Cryptography.Encryption(C.Expires_in.ToString());
                            App.Current.Properties[Cryptography.Encryption("TokenType")] = Cryptography.Encryption(C.Token_type);
                            App.Current.Properties[Cryptography.Encryption("Scope")] = Cryptography.Encryption(JsonConvert.SerializeObject(C.Scope));
                            App.Current.Properties[Cryptography.Encryption("RefreshToken")] = Cryptography.Encryption(C.Refresh_token);
                            App.Current.SavePropertiesAsync();
                        }
