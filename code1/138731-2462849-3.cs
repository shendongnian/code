    public class HomeController : Controller
    {
        public ActionResult Edit()
        {
            var page = new Page
            {
                Content = new EditableContent
                {
                    SidebarLeft = "left",
                    SidebarRight = "right"
                }
            };
            return View(page);
        }
        [HttpPost]
        public ActionResult Edit(Page page)
        {
            return View(page);
        }
    }
