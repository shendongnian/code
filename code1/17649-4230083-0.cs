    public class MyController : Controller
    {
        public ActionResult MyActionMethod(SearchBag searchBag)
        {
            Effects selectedEffect = searchBag.EffectIndicator;
        }
    }
