    public class Result{  
        public bool Result {  get; protected set; }
        public string Message {  get; protected set; }
        
        public Result(bool result, string message) {
            Result = result;
            Message = message;
        }
    }
