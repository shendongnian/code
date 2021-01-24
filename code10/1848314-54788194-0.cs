    namespace WebApplication1.Controllers
    {
        public class Session
        {
            public int SessionId { get; set; }
            public string Name { get; set; }
            public List<Trainee> Trainees { get; set; }
        }
    
        public class Trainee
        {
            public int TraineeId { get; set; }
            public string Name { get; set; }
    
        }
    
        public class SessionController : Controller
        {
            // GET: Session
            public ActionResult Index()
            {
                List<Session> sessions = new List<Session>();
                sessions.Add(new Session { SessionId = 1, Name = "Session 1"});
                sessions.Add(new Session { SessionId = 1, Name = "Session 2" });
                sessions.Add(new Session { SessionId = 1, Name = "Session 3" });
                return View(sessions);
            }  
        }
    }
    namespace WebApplication1.Controllers
    {
        public class TraineeController : Controller
        {
            public ActionResult Add(int sessionid)
            {
                List<Session> sessions = new List<Session>();
                sessions.Add(new Session { SessionId = 1, Name = "Session 1" });
                sessions.Add(new Session { SessionId = 1, Name = "Session 2" });
                sessions.Add(new Session { SessionId = 1, Name = "Session 3" });
                var session = sessions.FirstOrDefault(c => c.SessionId == sessionid);
                ViewBag.session = session;
                return View();
            }
    
           
            [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {
                    // TODO: Add insert logic here
    
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
    
         
        }
    }
