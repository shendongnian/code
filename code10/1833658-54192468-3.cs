            try
            {
                throw new System.Exception("I want to be in the response body.");
            }
            catch(Exception exception)
            {
                log.LogError(exception, exception.Message);
                var res = new ObjectResult(exception)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return res;
            }
