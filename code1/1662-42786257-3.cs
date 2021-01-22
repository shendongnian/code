    public class MyException : Exception
    {
        public MyException(string message, string extraInfo)
        {
            this.Message = $"{message} Extra info: {extraInfo}";
            // You can omit the 'this.' portion above...
        }
    }
