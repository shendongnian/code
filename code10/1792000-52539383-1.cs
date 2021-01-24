     public Task<IActionResult> Index()
        {
            var users  = await DbContext.GetUsersAsync();
            var groups = await DbContext.GetGroupsAsync();
          
            var m = new Model(){
             Users = users,
             Groups = groups
            }
        
            return View(m);
        }
