     public class PeopleController : Controller
        {
            // GET: People
            public ActionResult Index()
            {
                List<Person> people = Db.GetAllPeople();
                return View(people); //This is how you pass your strongly typed data to the view
            }
        }
