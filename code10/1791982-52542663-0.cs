        [HttpGet]
        public HttpResponseMessage GetStatus(GetStatusRequest request)
        {
           try
           {
              if (request.CustomerId>0 && String.IsNullOrEmpty(request.Customername) /*&& other conditions*/)
              {
                 var customers = GetCustomers(request.CustomerId);
        
                 return Request.CreateResponse(HttpStatusCode.OK, customers );
              }
              else 
              {
                   return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Your custom error message here");
              }
           }
           catch (Exception ex)
           {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ex.Message));
           }
        }
