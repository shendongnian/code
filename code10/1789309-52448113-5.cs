    using System.Net;
    public static async Task<HttpResponseMessage> Run(
                HttpRequestMessage req,
                IAsyncCollector<dynamic> documentsToStore)
            {
                dynamic data = await req.Content.ReadAsAsync<object>();
            
                if (data == null)
                {
                    return req.CreateResponse(HttpStatusCode.BadRequest);
                }
                await documentsToStore.AddAsync(data);
                return req.CreateResponse(HttpStatusCode.Created);
        }
