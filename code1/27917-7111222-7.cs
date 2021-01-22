    [HttpPost]
    [MultipleButton(Name = "action", Argument = "Save")]
    public ActionResult Save(MessageModel mm) { ... }
    [HttpPost]
    [MultipleButton(Name = "action", Argument = "Cancel")]
    public ActionResult Cancel(MessageModel mm) { ... }
