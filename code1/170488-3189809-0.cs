    public ActionResult EditView()
    {
        var da = new DataAccessClass();
        var Names = da.ReadActive(); // returns MyOtherModel
        var sli = new SelectList(evNames, "ID", "Name");
        ViewData.Add("OtherModelNames", new SelectList("ID", "Name", ""));
        return View();
    }
