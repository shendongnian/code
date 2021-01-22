     public ActionResult GetUsers()
            {
                var users = Membership.GetAllUsers();
                return View(users);
            }  
