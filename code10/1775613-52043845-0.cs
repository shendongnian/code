            static void Main(string[] args)
        {
            try
            {
                var resourceGroupName = "your ressource group name";
                var subId = "64da6c..-.......................88d";
                var appId = "eafeb071-3a70-40f6-9e7c-fb96a6c4eabc";
                var appSecret = "YNlNU...........................=";
                var tenantId = "c5935337-......................19";
                var environment = AzureEnvironment.AzureGlobalCloud;
                var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, appSecret, tenantId, AzureEnvironment.AzureGlobalCloud);
                var azure = Microsoft.Azure.Management.Fluent.Azure
             .Configure()
             .Authenticate(credentials)
             .WithSubscription(subId);
             
                azure.AppServices.WebApps.Inner.CreateOrUpdateHostNameBindingWithHttpMessagesAsync(resourceGroupName, "WebSiteName", "SubDomainName",
                  new HostNameBindingInner(
                            azureResourceType: AzureResourceType.Website,
                            hostNameType: HostNameType.Verified,
                            customHostNameDnsRecordType: CustomHostNameDnsRecordType.CName)).Wait();
            }
            catch (Exception ex)
            {
            }
        }
