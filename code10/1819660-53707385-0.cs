    extension = new OpenTypeExtension
                    {
                        ExtensionName = AzureADExtensions.UserConstants.ExtensionName,
                        AdditionalData = new Dictionary<string, object>
                        {
                            {"OtherEmail", externalUser.Email},
                            {"OtherRole" , externalUser.Roles.FirstOrDefault()}
                        }
                    };
    
                    await _graphClient.Users[user.Id].Extensions.Request()
                        .AddAsync(extension);
