    public class UnitTestTraceListener : DefaultTraceListener
    {
        public override void Fail(string message, string detailMessage)
        {
            string failMessage = message;
            
            if (detailMessage != null)
            {
                failMessage += " " + detailMessage;
            }
            
            // Call naar Assert van betreffende unit testing framework.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(
                failMessage);
        }
    }
