     public class PostsController : Controller
    {
            private ICompositeViewEngine _viewEngine;
           public PostsController(ICompositeViewEngine viewEngine)
           {
               _viewEngine = viewEngine;
           }
     } 
