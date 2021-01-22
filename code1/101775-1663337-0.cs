        public class Controller : System.Web.Mvc.Controller
    {
        public shipsEntities db = new shipsEntities();
        public Controller()
        {
            ViewData["ships"] = db.ships.ToList();
        }
    }
