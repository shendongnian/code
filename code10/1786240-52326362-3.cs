    public class Status
    {
        public bool IsError{get;set;}
        public string Message {get;set;}
        public Status(bool isError,string message)
        {
            IsError=isError;
            Message=message;
        }
    }
