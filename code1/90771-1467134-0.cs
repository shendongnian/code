    public interface IMetaDataViewModel
    {
        PageMetaData MetaData{get; set;}
    }
    public class HomeViewModel : IMetaDataViewModel
    {
        public PageMetaData MetaData{get; set;}
        public string HomePageText{get; set;}
    }
    //other view models go here....
    
    public class CommonPagesController : Controller
    {
        private MetaDataProvider _metaProvider = new MetaDataProvider();
        private PageDataProvider _pageDataProvider = new PageDataProvider();
        private ContactDataProvider _contactDataProvider = new ContactDataProvider();
        public ActionResult Home()
        {
            var viewModel = new HomeViewModel
            {
                MetaData = _metaProvider.GetPageMeta();
                HomePageText = _pageDataProvider.GetPageData();
            };
            return View(viewModel);
        }
        public ActionResult Contact()
        {
            var viewModel = new ContactViewModel
            {
                MetaData = _metaProvider.GetPageMeta();
                ContactFormData = _contactDataProvider.GetData();
            };
            return View(viewModel);
        }
        //you get the picture...
    }
