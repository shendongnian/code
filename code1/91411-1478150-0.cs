    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Submit(string user)
    {
        User submittedUser = JsonConvert.DeserializeObject<User>(user); 
        return View();
    }
