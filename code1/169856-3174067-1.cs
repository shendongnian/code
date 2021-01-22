    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                // TODO: Fetch from the database some enumerable collection 
                // containing Id and Name
                Items = new SelectList(new[]
                {
                    new { Id = 1, Name = "item 1" },
                    new { Id = 2, Name = "item 2" },
                }, "Id", "Name")
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // TODO: Do something with model.SelectedValue
            return RedirectToAction("index");
        }
    }
