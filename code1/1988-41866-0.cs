    public class BlogController : Controller
    {
       public ActionResult New()
       {
          var post = new Post();
          return View("Edit", post);
       }
    
       public ActionResult Edit(int id)
       {
          var post = _repository.Get(id);
          return View(post);
       }
    
       ....
      
    }
