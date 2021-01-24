    routes.MapRoute(
        name: "GroupsStudents",
        url: "Groups/{groupId}/{controller}/{action}",
        defaults: new {controller = "Students", action = "Create" });
    public ActionResult Create(int groupId)
     {
        ViewBag.GruopID = new SelectList(db.Groups, "GroupID", "Name", 
        db.Groups.First(p => p.GroupID == groupId));
        return View();
     }
