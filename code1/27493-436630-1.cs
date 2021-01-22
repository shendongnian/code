    public ActionResult Index()
    {
         ViewData["Title"] = "Home Page";
         ViewData["Message"] = "Welcome to ASP.NET MVC!";
         Person p = new Person();
         p.Name = "Barrack";
         p.Age = 35;
         ViewData["Person"] = p;
         return View();
    }
    public ActionResult Jump(string name, Person person)
    {
        return View();
    }
