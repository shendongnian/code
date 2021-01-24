    public class ChangeRequest: Hub, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        protected IHubContext<ChangeRequest> _context;
        public ILogger Logger { get; set; }
        public ChangeRequest(IHubContext<ChangeRequest> context)
        {
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
            _context = context;
        }
        public async Task SendMessage(string message)
        {
            await _context.Clients.All.SendAsync("getMessage", string.Format("User {0}: {1}", AbpSession.UserId, message));
        }
		
		}
   
 
