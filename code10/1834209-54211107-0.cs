        class Program
        {
            private static DataLakeStoreAccountManagementClient _adlsClient;
    
            private static string _adlsAccountName;
            private static string _resourceGroupName;
            private static string _location;
            private static string _subId;
    
            static void Main(string[] args)
            {
                _adlsAccountName = "test333";
                _resourceGroupName = "ivanrg";
                _location = "East US 2";
                _subId = "xxxx";
    
                string TENANT = "xxxx";
                string CLIENTID = "xxxx";
                System.Uri ARM_TOKEN_AUDIENCE = new System.Uri(@"https://management.core.windows.net/");
                System.Uri ADL_TOKEN_AUDIENCE = new System.Uri(@"https://datalake.azure.net/");
                string secret_key = "xxxx";
                var armCreds = GetCreds_SPI_SecretKey(TENANT, ARM_TOKEN_AUDIENCE, CLIENTID, secret_key);
    
                // Create client objects and set the subscription ID
                _adlsClient = new DataLakeStoreAccountManagementClient(armCreds) { SubscriptionId = _subId };
    
                // Create Data Lake Storage Gen1 account
                var adlsParameters = new DataLakeStoreAccount(location: _location);            
                
                _adlsClient.Account.Create(_resourceGroupName, _adlsAccountName, adlsParameters);
    
                Console.WriteLine("--completed--");
                Console.ReadLine();
            }
    
            private static ServiceClientCredentials GetCreds_SPI_SecretKey(string tenant, Uri tokenAudience, string clientId, string secretKey)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
                var creds = ApplicationTokenProvider.LoginSilentAsync(
                 tenant,
                 clientId,
                 secretKey,
                 serviceSettings).GetAwaiter().GetResult();
                return creds;
            }            
        }
