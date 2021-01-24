    public class RequestViewModel
    {
        public Guid SelectedGuid { get; set; }
        //Text=Name, Value=Guid
        public List<SelectListItem> Priorities { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Tut144(RequestViewModel selected)
        {
            RequestViewModel requestViewModel = GetData();
            return View();
        }
        public ActionResult Tut144()
        {
            RequestViewModel requestViewModel = GetData();
            return View(requestViewModel);
        }
        private static RequestViewModel GetData()
        {
            //prep the vcontroller-you can do this from db
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem selectListItemA = new SelectListItem { Text = "Priority1", Value = Guid.NewGuid().ToString() };
            SelectListItem selectListItemB = new SelectListItem { Text = "Priority2", Value = Guid.NewGuid().ToString() };
            SelectListItem selectListItemC = new SelectListItem { Text = "Priority3", Value = Guid.NewGuid().ToString() };
            list.Add(selectListItemA);
            list.Add(selectListItemB);
            list.Add(selectListItemC);
            RequestViewModel requestViewModel = new RequestViewModel { Priorities = list };
            return requestViewModel;
        }
