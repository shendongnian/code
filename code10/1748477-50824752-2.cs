    public class MyController:Controller
    {
       private IMyInterface _myClass;
       public MyController(IMyInterface myclass) {
          _myClass = myClass;
       }
    
       public IActionResult MyAction() {
          _myClass.MyFunction();
          return View();
       }
    }
