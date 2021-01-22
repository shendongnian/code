    public class JobController : Controller
    {
        [HttpPost]
        public RedirectToRouteResult DoSomeStuff(DoSomeStuffModel model)
        {
            //Do some stuff with model
            return RedirectToAction("Index");
        }
    } 
