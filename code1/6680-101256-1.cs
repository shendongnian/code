    public ActionResult MyAction()
    {
        ... // Populate myObject
        return new JsonResult{ Data = myObject };
    }
