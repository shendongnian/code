    public class EveryoneOfYourControllers : CustomController
    {
        public async Task<IActionResult> Index()
        {
            var model = await base.CreateModel<SomeModel>();
            // Set other properties on your model
            return View();
        }
    }
