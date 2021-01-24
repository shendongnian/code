    public ActionResult SetTraineeModel(string Id)
    {
        var model = new TraineeModel();
        model.CurrentTraineeId = Id;
        HttpContext.Current.Session["CurrentTrainee"] = model;
        return RedirectToAction("Index", "Time", null);
    }
