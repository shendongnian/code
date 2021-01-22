    [ErrorLogging]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(Models.Entities.Message message)
    {
        var dc = new Models.DataContext();
        dc.Messages.InsertOnSubmit(message);
        dc.SubmitChanges();
        return RedirectToAction("List", new { id = message.MessageId });
    }
