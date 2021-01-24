    public class HomeController : Controller
    {
        private readonly Foo _myFoo;
        public HomeController(Foo myFoo)
        {
            _myFoo = myFoo;
        }
    }
