    [Route("/something/{param}", "GET")]
    public class MyRequestArg{
       public string param{get;set;}
    }
    
    public class MyRequestService
    {
        public object Get(MyRequestArg request)
        {
        var url = "http://www.zombo.com";
        var myCookieString = "anything is possible!";
    
        var result = new HttpResult
                     {
                       StatusCode = HttpStatusCode.Redirect,
                       Headers = {
                                  {HttpHeaders.Location, url},
                                  {HttpHeaders.SetCookie, myCookieString}
                                 }   
                     };
        return result;
        }
    }
