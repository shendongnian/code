    // this implementation is for Asp.Net Identity, use whatever implementation you need.
    private IEnumerable<string> UserRoles 
        => ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
   
    
    public ActionResult SomeAction()
    {
         // do some processing
         var viewModel = new SomethingViewModel()
         {
             UserRoles = UserRoles.ToList()
         }
         return View(viewModel);
    }
