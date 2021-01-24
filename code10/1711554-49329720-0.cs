    public ActionResult YourAction()
    {
    ViewBag.TheJsonWhichIsTakingTime = YourBLL.Action();
    return view(model);
    }
