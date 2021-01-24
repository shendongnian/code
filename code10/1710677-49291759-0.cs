    public class GenericController<T> : Controller
        where T: class
    {
    
        public IActionResult Get()
        {
            return Content(typeof(T).FullName);
        }
    }
