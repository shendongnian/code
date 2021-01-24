    public class MainController : Controller
    {
        public ILogger Logger { get; set; }
        public RecordManager _recordMgr { get; set; } // Add
        public ActionResult Index(string SessionID)
        {
            Logger.Info("MainController - inside Index");
            _recordMgr.SessionID = SessionID; // Modify
            _recordMgr.PushRecords(); // Modify
        }
    }
    public class RecordManager, ITransientDependency // Modify
    {
        public ILogger Logger { get; set; }
        public string SessionID { get; set; } = string.Empty; // Modify
        public RecordManager(ILogger logger) // Modify
        {
            // _sessionID = sessionID; // Remove
            Logger = logger; // Modify
            Logger.Info("RecordManager - inside constructor");
        }
        public void PushRecords()
        {
            Logger.Info("RecordManager - PushRecords - start");
        }
    }
