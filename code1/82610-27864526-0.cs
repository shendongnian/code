    public ActionResult InitiateLongRunningProcess(Emails emails)
    {
        if (ModelState.IsValid)
        {
           HostingEnvironment.QueueBackgroundWorkItem(ct => LongRunningProcessAsync(emails.Email));
           return RedirectToAction("Index", "Home");
        }
     
        return View(user);
    }
