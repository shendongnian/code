    public enum InsertStatus{
    success = 0,
    failure =1 
    }
    public class InsertResponse
    {
     public InsertStatus status {get;set;}
     public string Message {get;set;}
     }
