    #r "System.Web.Http"
    
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    public static Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
