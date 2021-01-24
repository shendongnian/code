    public ActionResult AddAdmin()
    {
        DataAccessLayer.DoloContext col = new DataAccessLayer.DoloContext();
        var viewMod = new AdminViewModel();   
        List<Roles> list = col.Roles.ToList();
        viewMod.Roles = list.Select(x => new SelectListItem {
            Text = x.RoleName,
            Value = x.RoleId
        }).ToList();
        return View(viewMod);
    }
