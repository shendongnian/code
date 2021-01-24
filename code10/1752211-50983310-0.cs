        public class YourController : Controller
    {
        private readonly IEmailMessengerService _emailMessageService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        // dependency injection 
        public YourController
            (IUnitOfWorkFactory unitOfWorkFactory,
                IEmailMessengerService emailMessageService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _emailMessageService = emailMessageService;
        }
        // GET: YourController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(YourViewModel model)
        {
            #region backend validation
            if (
                !GoogleReCAPTCHAHelper.Check(Request["g-recaptcha-response"],
                    ConfigurationManager.AppSettings["GoogleReCAPTCHASecret"]))
            {
                ModelState.AddModelError(string.Empty, "You have to confirm that you are not robot!");
                return View(model);
            }
            // do your validation
            #endregion
            // do your needs here. 
        }
    }
