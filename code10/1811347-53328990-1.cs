     public class WriteDynamicFileController : ApiController
    {
    [System.Web.Http.AcceptVerbs("GET", "POST")]
    [System.Web.Http.HttpPost]
    public SimpleResponse POST([FromBody] SimpleRequest data)
    {
        String DynamicFileName = "";
        HttpResponseMessage response = new HttpResponseMessage();
        using (HostingEnvironment.Impersonate())
        {
            try
            {                  
                client.Headers.Add("X-Current-User", 
                base.User.GetUsername(true).ToString());
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.UseDefaultCredentials = true;
                DynamicFileName = client.UploadString(theURI, data);
                response.data = DynamicFileName;
            }
            catch (Exception ex)
            {                    
                response.ReasonPhrase = ex.InnerException.ToString();
                return response
            }
            return response;
        }
    }
    }
