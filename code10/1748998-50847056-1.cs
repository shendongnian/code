    public class ProfileController : Controller {
        
        //...code removed for brevity
        public ActionResult Index(string id) {
            //Get users profile from the database using the id
            var viewModel = _userProfileService.Get(id);
            if(viewModel == null) {
                return NotFound();
            }
            return View(viewModel);
        }
    }
