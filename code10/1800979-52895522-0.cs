    [HttpGet]
    public FileResult GetAvatar(string username)
    {
       User user = _repo.GetUser(username);
    
       if(user.UserDetail != null)
          return File(user.UserDetail?.UserPhoto, "image/png");
    
       return File("images/avatar_default.png", "image/png");
    }
