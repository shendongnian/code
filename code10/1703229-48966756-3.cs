    public ActionResult Search() {
        var model = new MembersModel();
        model.SearchColumnList = new List<SelectListItem> {
            new SelectListItem {Text = "Select A Column", Value = "1" },
            new SelectListItem {Text = "UserName", Value = "2" },
            new SelectListItem { Text = "FirstName", Value = "3" },
            new SelectListItem { Text = "LastName", Value = "4" }
        }
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Search(MembersModel model)
    {
        //Now your model will be populated with the values from the form
    }
