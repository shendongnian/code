            try
            {
                throw new System.Exception("I want to be in the response body.");
            }
            catch (Exception exception)
            {
                log.LogError(exception, exception.Message);
                return req.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
