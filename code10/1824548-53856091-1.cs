        [RoutePrefix("menuItems")]
    public class MenuItemController : Controller
    {
        // GET: MenuItem
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        [Route("Save")] // put the route attribuate 
        public ActionResult Save(MenuItemsViewModel model)
        {
            ViewBag.Message = "Information saved";
            return RedirectToAction("Index");
        }
    }
