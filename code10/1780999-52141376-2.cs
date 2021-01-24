                Utilities.Log("Authorizing the application associated with the current service principal...");
                vault1 = vault1.Update()
                        .DefineAccessPolicy()
                            .ForServicePrincipal(SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION")).ClientId)
                            .AllowKeyAllPermissions()
                            .AllowSecretPermissions(SecretPermissions.Get)
                            .AllowSecretPermissions(SecretPermissions.List)
                            .Attach()
                        .Apply();
                Utilities.Log("Updated key vault");
                Utilities.PrintVault(vault1);
                //============================================================
                // Update a key vault
                Utilities.Log("Update a key vault to enable deployments and add permissions to the application...");
                vault1 = vault1.Update()
                        .WithDeploymentEnabled()
                        .WithTemplateDeploymentEnabled()
                        .UpdateAccessPolicy(vault1.AccessPolicies[0].ObjectId)
                            .AllowSecretAllPermissions()
                            .Parent()
                        .Apply();
                Utilities.Log("Updated key vault");
                // Print the network security group
                Utilities.PrintVault(vault1);
