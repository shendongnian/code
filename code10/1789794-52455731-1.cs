        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login.Models.user usermodel)
        {
            using (LogEntities db = new LogEntities())
            {
                var userdetails = db.users.Where(x => x.USERNAME == usermodel.USERNAME && x.PASSWORD == usermodel.PASSWORD);
                if (userdetails == null)
                {
                    usermodel.ErrorMessage = "wrong inputs";
                    return View("Index", usermodel);
                }
                return View("Autherize");
            }
        }
