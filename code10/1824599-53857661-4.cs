    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<OPISPriceReportOLY_Result> results = new List<OPISPriceReportOLY_Result>();
            results.Add(new OPISPriceReportOLY_Result { cpid = 1 });
            results.Add(new OPISPriceReportOLY_Result { cpid = 2 });
            results.Add(new OPISPriceReportOLY_Result { cpid = 3 });
            return View(results);
        }
    
        [HttpPost]
        public ActionResult Update(OPISPriceReportOLY_Result model)
        {
            if (ModelState.IsValid)
            {
    
                int id = model.orpid;
    
                using (var context = new IntranetCoreEntities())
                {
                    var selected = context.OPISRetailPricings.Find(id);
                    selected.DMarkup = model.DMarkup;
                    selected.DSell = model.DSell;
                    selected.RMarkup = model.RMarkup;
                    selected.RSell = model.RSell;
                    context.SaveChanges();
                }
            }
    
            return RedirectToAction("Index");
        }
    }
