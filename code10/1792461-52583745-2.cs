    public class BearerAuthenticator : IAuthenticator {
        private readonly string authHeader;
        public BearerAuthenticator(string accessToken) {
            if (accessToken == null)
                throw new ArgumentNullException("accessToken");
            authHeader = $"Bearer {accessToken}";
        }
        public void Authenticate(IRestClient client, IRestRequest request) {
            // only add the Authorization parameter if it hasn't been added by a previous Execute
            if (!request.Parameters.Any(p => p.Type.Equals(ParameterType.HttpHeader) &&
                                             p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                request.AddParameter("Authorization", authHeader, ParameterType.HttpHeader);
        }
    }
