    public class SomeAppLogic
    {
        public SomeAppLogic(Func<Test> testFactory)
        {
            // Some app logic
            for (int i = 0; i < 10; i++)
            {
                // Invoke the testFactory to obtain a new instance 
                // of a Test class from the IoC container
                Test newTestInstance = testFactory.Invoke();
            }
        }
    }
