    public IHttpActionResult GetAllUsers()
            {
                try
                {
                    List<User> Users = Common.Framework.Persistence.PersistSvr<Business.Entity.User>
                                       .GetAll().ToList(); 
                    return Ok(Users);
    
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError, ex.Message);
    
                }
            }
