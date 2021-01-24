    public class MainController : Controller
    {
        public ILogger Logger { get; set; }
        public IIocResolver IocResolver { get; set; } // Add
        public ActionResult Index(string SessionID)
        {
            Logger.Info("MainController - inside Index");
            using (var wrapper = IocResolver.ResolveAsDisposable<RecordManager>(new { sessionID = SessionID })) // Modify
            {
                var recordMgr = wrapper.Object; // Add
                recordMgr.PushRecords();
            }
        }
    }
    public class RecordManager : ITransientDependency // Modify
    {
        public ILogger Logger { get; set; }
        private string _sessionID = string.Empty;
        public RecordManager(string sessionID, ILogger logger) // Modify
        {
            _sessionID = sessionID;
            Logger = logger; // Modify
            Logger.Info("RecordManager - inside constructor");
        }
        public void PushRecords()
        {
            Logger.Info("RecordManager - PushRecords - start");
        }
    }
