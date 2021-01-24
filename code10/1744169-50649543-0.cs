    [HttpGet] //Change this from HttpPost to HttpGet.
    public ActionResult Delete(int? queryId)
    {
        var userId = CurrentUser.Id;
        UserQueryService uqs = new UserQueryService();
        uqs.Delete(userId, (int)queryId);
        return View("Index", new UserQueryService().GetByUserId(userId));
    }
