    public class HomeController : Controller
    {
        public ActionResult Updateinc()
        {
            var model = new SampleViewModel
            {
                IncidentListmodel = new List<IncidentListmodel>
                {
                    new IncidentListmodel {Id = 1, Name = "One", Note = "Sample text"},
                    new IncidentListmodel {Id = 2, Name = "Two"},
                    new IncidentListmodel {Id = 3, Name = "Three"},
                }
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Updateinc(IncidentListmodel viewModel)
        {
            // Rediret to different page.
            return RedirectToAction("Index");
        }
    }
