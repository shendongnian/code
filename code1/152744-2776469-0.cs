    public ActionResult Test()
            {
                  ViewData["DataForPartial"] = new PartialDataObject();
                  return View("Test")
            }
