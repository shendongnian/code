    [HttpPost]
    public ActionResult GetClientMatch(ClientBusinessModel contactPerson)
    {
        // *search for a list*
        if (list.Count > 0)
        {
            return PartialView("~/Views/Shared/Partials/_Client.cshtml", list);
        } 
        else
        {
            // key name intentionally changed for disambiguation
            return Json(new { contact = contactPerson }, JsonRequestBehavior.AllowGet);
        }
    }
