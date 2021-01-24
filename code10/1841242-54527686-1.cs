    //DELETE: api/UserAPI/5
        [HttpPost]
        [Route("api/UserAPI")]
        public HttpResponseMessage Delete(UserViewModel uservm)
        {
            try
            {
                User usr = new Models.User();
                
                var register = ctx.User.Where(x => x.UserId == uservm.UserId).SingleOrDefault();
                uservm.IsDelete = true;
                if (register != null)
                {
                    register.IsDelete = uservm.IsDelete;
                    ctx.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Record not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
