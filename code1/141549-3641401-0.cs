    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ExchangeService service = new ExchangeService();
            service.Credentials = new NetworkCredential("username", "pwd", "domain");
            service.AutodiscoverUrl("foo@company.com");
            // Get all folders in the Inbox
            IEnumerable<FolderViewModel> model = service
                .FindFolders(WellKnownFolderName.Inbox, new FolderView(int.MaxValue))
                .Select(folder => new FolderViewModel { Id = folder.Id.UniqueId });
            return View(model);
        }
        public ActionResult Bind(string id)
        {
            Folder folder = Folder.Bind(service, new FolderId(id));
            // TODO: Do something with the selected folder
            return View();
        }
    }
