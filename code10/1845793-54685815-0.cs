    public class MyResult
    {
        public bool Succeeded {get;}
        public string ErrorMessage {get;}
 
        public MyResult(bool succeeded, string errorMessage)
        {
            Succeeded = succeeded;
            ErrorMessage = errorMessage;
        }
    }
    public Task<MyResult> DelUserTemp(string UserID, int FingerIndex ,out string result)
    {
        return Task.Run(() =>
        {
            if (true)
            {
                return new MyResult(true, "done");
            }
            else
            {
                return new MyResult(false, "error");
            }
        });
    }
