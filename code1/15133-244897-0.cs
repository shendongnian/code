    public class WebRequestWrapper
    {
       internal WebRequestWrapper() {..}
    
       public WebRequestWrapper(WebRequest req)
       {
          _innerRequest = req;
       }
    
    
       public virtual string Url
       {
          return _innerReq.Url;
       }
    
       //repeat, make all necessary members virtual
    }
