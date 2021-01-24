    namespace Testy20161006.Controllers
    {
        public class Home2Controller : Controller
        {
            //I named my Controller Home2 and Action MyAction2, but you can name it anything you want
            public ActionResult MyAction2(string passedData)
            {
                //reconstruct the ViewModel and pass into second view
                NewbieDevViewModel viewModel = new NewbieDevViewModel { DataToPassToNewControllerAction = passedData };
                return View(viewModel);
            } 
