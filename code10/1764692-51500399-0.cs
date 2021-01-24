    public interface ISmsProvider 
    {
        (bool, string) SendMessage(string number, string message);
    }
    public class SampleSmsProvider1 : ISmsProvider
    {
        public SampleSmsProvider1(string userKey, string passKey) 
        {
            // initialize           
        }
        public (bool, string) SendMessage(string number, string message) 
        {
            // send the message (using a provider implementation from NuGet perhaps)
            
            // return success/fail and error message, if applicable
            return (true, string.Empty);
        }
    }
    public class SmsFactory
    {
        public ISmsProvider GetProvider() 
        {
            // Initialize and return one of the ISmsProvider implementations, depending on (I guess) the configuration
        }
    }
