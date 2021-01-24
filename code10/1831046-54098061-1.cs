    public class UserLogViewModel
    {
        public string UserName { get; set; }
        public string EndPoint { get; set; }
        public string Date { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly SMARTEntities3 _db = new SMARTEntities3();
        [HttpPost]
        public ActionResult MyIndex([Bind(Include = "UserName, EndPoint, Date")]  UserLogViewModel log)
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                //from viewmodel to object
                UserLog userLog = new UserLog { Date = DateTime.Parse(log.Date), EndPoint = log.EndPoint, 
                    UserName = log.UserName };
                _db.UserLogs.Add(userLog);
                _db.Entry(log).State = EntityState.Added;
                _db.SaveChanges();
            }
            return View();
        }
        public ActionResult Tut142()
        {
            return View();
        }
