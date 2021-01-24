    public class UserController: Controller
    {
        [HttpGet]
        public ActionResult CreateUser()
        {
             return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
              // save the user here
              ViewBag.SuccessMessage = user.UserName + " has been created successfully!"
              ModelState.Clear();
              return View();
            }
            return View(user);
       }
    }
    
