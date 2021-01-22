        public sealed class WcfLoginManager : ILoginManager
        {
            private static LoginManagerClient GetWcfClient()
            {
                return 
                    new LoginManagerClient(
                        WcfBindingHelper.GetBinding(),
                        WcfBindingHelper.GetEndpointAddress(ServiceUrls.LoginManagerUri));
               
            }
            public LoginResponse Login(LoginRequest request)
            {
                using(var loginManagerClient = GetWcfClient())
                using (var slice = new WcfWrapper(loginManagerClient.InnerChannel))
                {
                    DSTicket ticket;
                    DSAccount account;
                    return slice.Function(() => new LoginResponse(loginManagerClient.Login(request.accountName, request.credentials, out ticket, out account), ticket, account));
                }
            }
        }
