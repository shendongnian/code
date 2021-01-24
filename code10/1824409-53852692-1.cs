    public IActionResult Index()
            {
                if (User.Identity.IsAuthenticated & !HttpContext.Session.Keys.Contains("Key"))
                {
                    HttpContext.Session.SetInt32("Key", 1);
                    return RedirectToAction("Index", "Encrypt");
                }
                else 
                    return View();
            }
