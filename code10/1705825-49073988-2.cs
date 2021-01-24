     [Route("api/Player/videos")]
        public HttpResponseMessage GetVideoMappings()
        {
            var model = new MyCarModel();
            return Request.CreateResponse(HttpStatusCode.OK,model,Configuration.Formatters.JsonFormatter);
        }
