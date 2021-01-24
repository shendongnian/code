     [System.Web.Http.HttpPost]
     [System.Web.Http.ActionName("TestMethod")]
     public HttpResponseMessage TestMethod([FromBody]EmployeeDetails employeeDetails)
     {
        //SomeCode
         return Request.CreateResponse(HttpStatusCode.OK, response.GenerateResponse());
     }
