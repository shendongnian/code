    public class MyException : Exception
    {
        public MyException(string message, string extraInfo) : base(message)
        {
            this.Message = $"{message} Extra info: {extraInfo}";
            // You can omit the 'this.' portion above...
        }
    }
