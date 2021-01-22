    class PreviewController : Controller
    {
        public ActionResult Details(string slug)
        {
            var model = db.GetItemBySlug(slug);
            return View("Details", model);
        }
    }
