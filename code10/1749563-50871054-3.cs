            [HttpPost, Route("add")]
            public IHttpActionResult AddEmployee(AddEmployeeRequestDTO request)
            {
                try
                {
                    if (request == null)
                        return Content(HttpStatusCode.BadRequest, ErrorCodes.E002);
                  
                }
                catch (Exception ex)
                {
    #if (DEBUG)
                    Logger.Instance.Error(ex);
                    throw ex;
    
    #endif
                    //Logger.Instance.Error(ex);
                    //return Content(HttpStatusCode.InternalServerError, ErrorCodes.E001);
                }
            }
