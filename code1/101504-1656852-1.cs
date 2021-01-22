    [RespondTo]
    public ActionResult Index(int id)
    {
        var messages = new string[0];
        if (id > 0)
        {
            // TODO: Fetch messages from somewhere
            messages = new[] { "message1", "message2" };
        }
        return View(messages);
    }
