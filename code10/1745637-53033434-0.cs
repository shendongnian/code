    public class IisLogFileHub : Hub
    {
        IHubContext<IisLogFileHub> _hubContext = null;
    
        public IisLogFileHub(IHubContext<IisLogFileHub> hubContext)
        {
            _hubContext = hubContext;
        }
    }
