    public ActionResult SomeAction(SomeModel model)
    {
        if (!ModelState.IsValid)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView("_NameOfPartial", model);
        }
    }
