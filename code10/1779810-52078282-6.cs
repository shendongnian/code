    public class TrainManagerController : Controller
    {
        private TrainContext context;
        public TrainManagerController()
        {
            context = new TrainContext();
        }
        public ViewResult Index()
        {
            return View(context.GetTrains());
        }
        public RedirectToRouteResult DeleteFromList(int TrainNumber)
        {
            context.Delete(TrainNumber);
            return RedirectToAction("Index");
        }
    }
