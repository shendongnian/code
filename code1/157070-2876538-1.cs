    public abstract class Request
    {
       // each request has it's own approval algorithm. Each has to implement this method
       public abstract void Approve() { }
       // refuse algorithm is common for all requests
       public void Refuse() { }
       // static helper
       public static void CheckDelete(string status) { }     
       // common property. Used as a comment for any operation against a request
       public string Description { get; set; }
       // hard-coded dictionary of css classes for server-side markup decoration
       public static IDictionary<string, string> CssStatusDictionary
    }
    
    public class RequestIn : Request
    {
       public override void Approve() { }
    }
    
    public class RequestOut : Request
    {
       public override void Approve() { }
    }
