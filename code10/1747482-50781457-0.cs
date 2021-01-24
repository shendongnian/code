    [HttpRoute("api/operations/TestMethod")] 
    public HttpResponseMessage TestMethod(string EmployeeDetails)
         {
            //SomeCode
             return Request.CreateResponse(HttpStatusCode.OK, response.GenerateResponse());
         }
