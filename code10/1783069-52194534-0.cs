    [HttpGet]
    [Authorize]
            public JsonResult Get()
            {
                var r = new Dictionary<String, Object>();
    
                r.Add("User.Identities", User.Identities);
                r.Add("User.Claims", User.Claims);
                r.Add("HttpContext.User.Identities", HttpContext.User.Identities);
                r.Add("HttpContext.User.Claims", HttpContext.User.Claims);
    
                return Json(r );
            }
