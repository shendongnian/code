    public class StudentController : Controller
    {
    	private static readonly List<StudentVM> _students = new List<StudentVM>();
    	
        public ActionResult Index()
        {
    		StudentVM obj1 = new StudentVM();
            obj1.Name = "Zeeshan";
            obj1.id = "1";
            obj1.Address = "Lahore";
    
            _students.Add(obj1);
    
            StudentVM obj2 = new StudentVM();
            obj2.Name = "Zeshan";
            obj2.id = "2";
            obj2.Address = "Lahore";
    
            _students.Add(obj2);
    		
            return View(students);
        }
    
        public ActionResult Delete(string i)
    	{
    		var student = _students.FirstOrDefault(c => c.id == i);
    		
    		if(student == null){ /* Failed to find student */ }
    		
    		_students.Remove(student);
    		return View("Index");
    	}
    }
