    [HttpGet]
    public ActionResult GetItem(int postId)
    {
      var post = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);
      if (post != null)
      {
        return View(post);
      }
      
      return View();
    }
