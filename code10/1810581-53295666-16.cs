    public class HomeController : Controller
    {
        private readonly IViewRender _viewRender { get; set; }
    
        public HomeController(IViewRender viewRender)
        {
            _viewRender = viewRender;
        }
    
        public IActionResult GetHTML()
        {
            string htmlWithoutModel = _viewRender.Render("Home/GetHTML");
    
            var model = new ModelClass() { Content = "Hi!" };
    
            string htmlWithModel = _viewRender.Render<ModelClass>("Home/GetHTML", model);
    
            //...
        }
    }
