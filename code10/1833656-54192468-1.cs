            try
            {
                throw new System.Exception("I want to be in the response body.");
            }
            catch(Exception exception)
            {
                var res = new ObjectResult(exception)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return res;
            }
