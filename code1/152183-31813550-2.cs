    public class LeadHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            // Just enough code to preserve the route's json interface for tests
            var typedResult = new PsaLeadSubmissionResult();
            typedResult.Registered = false;
            typedResult.Message = new List<string>
                                  {
                                      "Not Implemented"
                                  };
            var jsonResult = JsonConvert.SerializeObject(typedResult);
            context.Response.Write(jsonResult);
        }
    }
