    [HttpPost]
    public ActionResult GetName(string Name)
    {
        string SecondString = "secondString";
        return Json(new { Name = Name, SecondString = SecondString });
    }
