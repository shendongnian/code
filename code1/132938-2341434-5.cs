    public class UnitTestTraceListener : DefaultTraceListener
    {
        public override void Fail(string message, string detailMessage)
        {
            string failMessage = message;
            
            if (detailMessage != null)
            {
                failMessage += " " + detailMessage;
            }
            
            // Call to Assert method of used unit testing framework.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(
                failMessage);
        }
    }
