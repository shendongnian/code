        [Route("IntermediaryData/CheckUserAuthentication")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage CheckUserAuthentication(string UserName, string Password)
        {
            DomUserAuthentication objauthentication = new DomUserAuthentication();
            var res = Request.CreateResponse(HttpStatusCode.OK);
            /////Code here
            res.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return res;
        }
