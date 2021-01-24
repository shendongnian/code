    public Task<IActionResult> Index()
    {
        var users  = DbContext.GetUsersAsync();
        var groups = DbContext.GetGroupsAsync();
        
         await Task.WhenAll(users,groups);
    
        var m = new Model(){
         Users = users.Result,
         Groups = groups.Result
        }
    
        return View(m);
    }
