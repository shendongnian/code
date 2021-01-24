    [HttpPut]
        [Route("api/UserAPI")]
        public HttpResponseMessage Delete(int userId)
        {                                       
             var foundUser = ctx.User.Find(userId);
             foundUser.IsDeleted = true;
             ctx.SaveChanges();
        }
