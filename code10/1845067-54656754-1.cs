    [HttpPost]
    public ActionResult LikePost(User user)
    {
        return Content("User Id  Is  : " + user.userId + "Post Id  is : " + user.entryId);
    }
