    public class SignalrAuthorizationProvider : IAuthorizationProvider
    {
        private Boolean _isInitialized;
        private String _userId;
        public String UserId
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exception("SignalR hack not initialized");
                }
                return this._userId;
            }
        }
        public void OnConnected(HubCallerContext context)
        {
            this.Initialize(context);
        }
        public void OnReconnected(HubCallerContext context)
        {
            this.Initialize(context); 
        }
        private void Initialize(HubCallerContext context) {
            this._userId = context.QueryString["UserId"];
            this._isInitialized = true;
        }
    }
