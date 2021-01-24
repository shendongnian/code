    [ModelBinder(BinderType =typeof(AuthorizationHeaderBinder))]
    public class AccessTokenAuthorizationHeader
    {
        public string TokenValue { get; set; }
    }
