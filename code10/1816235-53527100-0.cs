    [Authorize]
    public ActionResult UserTopNavBar()
    {
         var userTopNavBarViewModel = new UserTopNavBarViewModel();
         using(ApplicationDbContext _db = new ApplicationDbContext())
         {
             var user = _db.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
             if (user != null)
             {
                 userTopNavBarViewModel.Name = user.FirstName + " " + user.LastName;
                 userTopNavBarViewModel.Picture = user.Picture;
                 userTopNavBarViewModel.Id = user.Id;
             }
         }
         return PartialView(userTopNavBarViewModel);
    }
