            try
            {
                throw new System.Exception("I want to be in the response body.");
            }
            catch (Exception exception)
            {
                return req.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
