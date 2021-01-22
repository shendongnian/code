    public ActionResult Action()
    {
        var vd = new MyViewData();
        vd.Blah = "asdf asdfsd";
        ViewData.Model = vd;
        return View();
    }
