    class Response<T> {
            public HttpStatusCode Status { get; private set; }
            public T Body { get; private set; }
            public bool Success { get; private set; }
            public string Reason {get; private set; }
    
            public Response(T body) {
                Success = true;
                Body = body;
                HttpStatusCode = HttpStatusCode.OK
            }
    
            public Response(string reason)
            {
                Reason = reason;
                Success = false;
                Status = HttpStatusCode.BadRequest;
            }
    
            public Response( string reason, HttpStatusCode status)
            {
                Reason = reason;
                Status = status;
                Success = false;
            }
        }
