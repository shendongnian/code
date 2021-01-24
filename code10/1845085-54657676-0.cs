             [FunctionName("HttpRunSingle")]
            public static async Task<HttpResponseMessage> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "orchestrators/contoso_function01/{id:int}/{username:alpha}")]
            HttpRequestMessage req, int id, string username,TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
                        
                return (id == 0 || string.IsNullOrEmpty(username))
                    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                    : req.CreateResponse(HttpStatusCode.OK, "Hello " + id + " " + username);
            }
