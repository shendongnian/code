    public class AccountServiceClientWrapper : ServiceProxyHelper<AccountServiceClient, IAccountService>
    {
    private endpointCfgName = "{endpoint_here}";
    
    public AccountServiceClientWrapper(): base(new AccountServiceClient(endpointCfgName))
            {
                //this.Proxy.ClientCredentials.UserName.UserName = "XYZ";
                //this.Proxy.ClientCredentials.UserName.Password = "XYZ";
            }
    }
