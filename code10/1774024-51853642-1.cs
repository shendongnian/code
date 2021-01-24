    public ActionResult _SampleAction(string ID)
    {
        MyModel objMyModel = new MyModel();
        objMyModel.ID = ID;
        try
        {
            // do something
            return PartialView("_SampleAction", objMyModel);
        }
        catch (Exception ex)
        {
            return Json(new { url = Url.Action("Index", "Error"), message = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }
