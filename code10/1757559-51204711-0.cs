        public HttpResponseMessage GetByMsn(string msn, DateTime dt)
        {
                try
                {
                   Log.Debug(String.Format("{0} started",  MethodBase.GetCurrentMethod().Name;));
                   ...
                   Log.Debug(String.Format("{0} succeeded",  MethodBase.GetCurrentMethod().Name;));
                } 
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
       }
