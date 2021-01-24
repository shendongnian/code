    public class MyController : Controller
    {
        
        MyDataForViews myData;
        // in controllers injection is done using the constructor 
        public MyController(MyDataForViews MyData) => myData = MyData;
        public IActionResult Index()
        {
            myData = ....   // assign all required data here
            View();
        }
    }
