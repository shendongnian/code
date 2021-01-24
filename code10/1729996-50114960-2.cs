    public class StudentController : Controller
        {
            private readonly IStudentService _service;
    
            public StudentController(IStudentService service)
            {
                _service = service;
            }
    
            // GET: Student
            public ActionResult Index()
            {
                IEnumerable<StudentView> studentViews = _service.GetStudentViews();
                return View("Index", studentViews);
            }
    }
