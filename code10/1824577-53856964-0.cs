        public HttpResponseMessage Post([FromBody]UserModel user)
        {
            SQL.InsertUser(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
