    [HttpGet]
    public ViewResult Edit(int groupId) {
      //your logic here
      var model = new MyModel() {
        GroupID = groupId
      };
      return View("Edit", model);
    }
    [HttpPost]
    public ActionResult AddUser(int groupId, string username) {
      //your logic here
      return RedirectToAction("Edit", new { GroupID = groupId });
    }
    [HttpPost]
    public ActionResult RemoveUser(int groupId, string username) {
      //your logic here
      return RedirectToAction("Edit", new { GroupID = groupId });
    }
