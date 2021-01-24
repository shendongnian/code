    //DELETE: api/UserAPI/5
        [HttpPut]
        [Route("api/UserAPI")]
        public HttpResponseMessage Delete(int userId)
        {
            try
            {
                var foundUser = ctx.User.Find(userId);
                if (foundUser != null)
                {
                    foundUser.IsDelete = true;
                    ctx.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
    }
