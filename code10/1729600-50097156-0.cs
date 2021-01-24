     HttpContext.Current = FakeHttpContext();
     HttpContext.Current.Session.Add("User", Id);
     if (Id != 0)
         {
            return RedirectToAction("Home", "Home", new { Id});
         }
    
      return RedirectToAction("Register", "Home", new { Id});
