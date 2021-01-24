    [HttpPost]
    public ActionResult Transfer(long id)
    {
      *some actions*
      return Json(new { newUrl = PartialView("~/Views/Shared/Partials/Leads/_TransferPopup.cshtml", commonModel) });
    }
