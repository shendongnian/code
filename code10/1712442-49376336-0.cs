    #r "System.Web"
    using System.Web;
    using System.Net;
    using System.Net.Http.Headers;
    public static HttpResponseMessage Run(HttpRequestMessage req,TraceWriter log)
    { 
        var response = req.CreateResponse(HttpStatusCode.OK);
        var stream = new FileStream(@"d:\home\site\wwwroot\HttpTriggerCSharp4\view\Home\index.html", FileMode.Open);
        response.Content = new StreamContent(stream);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
        return response;
    }
