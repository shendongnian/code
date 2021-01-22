    [HandleException]
    public Response DoSomething(Request request)
    {
       ...
    
       return new Response { Success = true };
    }
    
    public class Response
    {
       ...
       public bool Success { get; set; }
       public string StatusMessage { get; set; }
       public int? ErrorCode { get; set; }
    }
    
    public class Request
    {
       ...
    }
