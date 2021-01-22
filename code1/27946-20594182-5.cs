    [MultipleButtonsEnumAttribute(typeof(ButtonType))]
    public ActionResult Manage(ButtonType buttonPressed, ManageViewModel model)
    {
        if (button == ButtonType.Cancel)
        {
            return RedirectToAction("Index", "Home");
        }
        //and so on
        return View(model)
    }
