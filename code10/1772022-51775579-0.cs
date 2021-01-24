    public class OAuthController : AsyncController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> BeginAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"]
                }
            };
