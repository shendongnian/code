    public abstract class CustomHub : Hub
    {
        public CustomHub(IAuthorizationProvider authorizationProvider)
        {
            this._authorizationProvider = authorizationProvider;
        }
        private readonly IAuthorizationProvider _authorizationProvider;
        public override Task OnConnected()
        {
            this._authorizationProvider.OnConnected(this.Context);
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            this._authorizationProvider.OnReconnected(this.Context);
            return base.OnReconnected();
        }
    }
