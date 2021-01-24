    public class IndexModel : PageModel {
        private readonly IMyClass _myClass;
        public IndexModel(IMyClass myClass)
        {
            _myClass = myClass;
        }
        public void OnGet()
        {
           _myClass.SampleMethod();
        }
    }
