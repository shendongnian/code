    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Message(int ID, string SomeText)
    {
      // save Text to database
      SaveToDB(ID, SomeText);
    
      TempData["message"] = "Message sent";
      return RedirectToAction("Message");
    }
