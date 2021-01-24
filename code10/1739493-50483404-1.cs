    public class ClassController : Controller
    {
        DAL.DB dblayer = new DAL.DB();
    
        public ActionResult Class(ClassModel ClassModel)
        {
            ViewBag.Message = TempData["Message"];
            List<ClassModel> students = dblayer.getClass(ClassModel.ClassID);
    
            return View(students);
        }
    }
