        public static async Task<HttpResponseMessage> Run(
            HttpRequestMessage req,
            out dynamic documentToSave)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
        
            if (data == null)
            {
                documentToSave = null;
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            documentToSave = data;
            return req.CreateResponse(HttpStatusCode.Created);
    }
