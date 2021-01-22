    using Microsoft.AspNet.Identity;
    
    
    if (Request.IsAuthenticated)
    {
        return View();
    }
