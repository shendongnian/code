    public abstract class Request
    {
       public abstract void Approve() { }
       public static void CheckDelete(string status) { }
       public void Refuse() { }       
       public string Description { get; set; }
    }
    
    public class RequestIn : Request
    {
       public override void Approve() { }
    }
    
    public class RequestOut : Request
    {
       public override void Approve() { }
    }
