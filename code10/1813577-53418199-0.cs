    [HttpPost]
    public JsonResult GetUserServices()
            {
                var user = userManager.FindByNameAsync(User.Identity.Name);
                db.Configuration.ProxyCreationEnabled = false;
                var services = db.Services.Where(s => s.DistrictId == user.DistrictId).OrderBy(s => s.Name);
                return Json(services);
            }
