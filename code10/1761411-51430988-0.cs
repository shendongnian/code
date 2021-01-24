    public class DrinkssController : Controller
    {
        [Route("drink/{drinkName}")]
        public ActionResult Index(string drinkName)
        {
        	var model = _drinks.First(x => x.name == drinkName);
        	return View(model);
        }
    }
