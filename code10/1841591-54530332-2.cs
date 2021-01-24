     public class Controller2Controller : Controller
     {       
        public ActionResult GetSubject()
        {
            Subject s = new Subject() { id = 2, SubjectName = "XYZ" };
            return PartialView(s);
        }        
     }
