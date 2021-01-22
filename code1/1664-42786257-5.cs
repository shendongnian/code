    public class MyException: Exception
    {
        public MyException(string message, string extraInfo) : base($"{message} Extra info: {extraInfo}")
        {
        }
    }
