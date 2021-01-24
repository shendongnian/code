          [HttpPost]
        public HttpResponseMessage Post()
        {
            var query = this.Request.RequestUri.Query;
            query.Remove(0);
            List<string> paramteters = query.Split('&').ToList();
         }
