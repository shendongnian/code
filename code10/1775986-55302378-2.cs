    [HttpGet]
        public IActionResult SomethingToDo()
        {
            //... some code for my controller
            //Section for handling cookies
            //set the key value in Cookie  
            SetCookie("MyOwnKey", "Hello World from cookie", 15.0);
            //read cookie from IHttpContextAccessor 
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["MyOwnKey"];
            //or 
            string cookieValueFromRequest = GetCookie("kay");
            //Delete the cookie object  
            //RemoveCookie("Key");
            ViewData["CookieFromContext"] = cookieValueFromContext;
            ViewData["CookieFromRequest"] = cookieValueFromRequest;
            return View();
        }
