    public class UserController : Controller
    {
        public ActionResult Show(int id)
        {
            var model = new UserViewModel {Id = id};
            // Retrieve user from data layer and update model with other user details here
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            // Deal with edit action in here
        }
    }
    
    public class UserViewModel
    {
        public int Id { get; set; }
    }
