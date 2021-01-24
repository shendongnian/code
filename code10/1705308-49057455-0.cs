    public class HomeController : Controller
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SimulationDBEntities"].ToString());
        
        public List<QuoteTechModel> List()
        { 
         return conn.Query<QuoteTechModel>("USE SimulationDB; SELECT a.QTName As Name FROM QuoteTechInfo a").ToList();
        }
       
        public ActionResult Index()
        {
            ViewBag.techList = List();
            return View();
        } 
    }
