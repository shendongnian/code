    [HttpPost]
    public IHttpActionResultLogin()
    {
         OnlineUsers user = new OnlineUsers();
         user=YourUserDetailsMethod();
         return Ok(user);
    }
