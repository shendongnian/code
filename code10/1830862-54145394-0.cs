    public class SignalrAuthorizationProvider {
        public SignalrAuthorizationProvider(HubCallerContext context){
            this._context = context;
        }
        private readonly HubCallerContext _context; 
        public long? GetUserId() {
            return this._context.Request.QueryString["UserId"]
        }
    }
