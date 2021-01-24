    public class BigMBViewModel
    {
        public IList<SelectListItem> QuestionMultiSelectList { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Tut141(FormCollection formCollection)
        {
            ArrayList results = new ArrayList();
            for (int i = 0; i < formCollection.Count; i++)
            {
                if (formCollection[i].Contains("List"))
                {
                    results.Add(formCollection[i]);
                }
            }
            return View();
        }
        public ActionResult Tut141()
        {
            //I am using entity framework.  You can use plain ADO
            //read the the QuestionnaireTable into the Viewbag (into ViewBag.QuestionsList
            using (SMARTEntities2 entity = new SMARTEntities2())
            {
                ViewBag.QuestionsList = entity.Questionnaires.ToList();
            }
            BigMBViewModel bmbViewModel = new BigMBViewModel { QuestionMultiSelectList = new List<SelectListItem>() };
            using (SMARTEntities2 entity = new SMARTEntities2())
            {
                entity.QuestionMultiSelects.ToList().ForEach(r => bmbViewModel.QuestionMultiSelectList.Add(
                    new SelectListItem { Text = r.Options, Value = r.ListOfAnswersID + "-" + r.Id.ToString() }));            }
            return View(bmbViewModel);
        }
