    public ActionResult RenderMyView()
    {
      try
      {
        data = // some data to used in rendering my partial view
        return PartialView("PartialView", data);
      }
      catch(Exception e)
      {
        //catches any errors returns it back as plain text
        //log the error that was thrown
        return Content("Error: " + e.Message);
      }
    }
