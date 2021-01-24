    public class TrainManagerController : Controller
    {
        // the train list is set at Controller level
        private List<Trains> TrainList;
        // and populated when the controller is instantiated
        public TrainManagerController(List<Trains> trainList)
        {
            TrainList = trainList;
        }
        // this calls the view with the train list you have at the moment
        public ViewResult Index()
        {
            return View(TrainList);
        }
        // this deletes the train, then calls the index view.
        public RedirectToRouteResult DeleteFromList(int TrainNumber)
        {
            TrainList.Remove(TrainList.FirstOrDefault(t => t.tno == TrainNumber));
            return RedirectToAction("Index");
        }
    }
