    public class ClientAuthorizationService : IClientAuthorizationService {
        public ClientAuthorizationService() {
            CurrentClient = new MobileServiceClient(Constants.ApiConstants.ApplicationUrl);
        }
        public IMobileServiceClient CurrentClient { get; set; }
    } 
