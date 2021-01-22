    public ActionResult Save(int id, string title, string body)
    {
       var post = id == 0 ? new Post() : _repository.Get(id);
       post.Title = title;
       post.Body = body;
    
       _repository.Save(post);
    
       return RedirectToAction("list");
    }
