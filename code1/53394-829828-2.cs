    public interface ITest : IProvider
    {        
    }
    public class TestConsumer : IConsumer
    {
        public void Initialize(ILoader loader)
        {
            ITest tester = (ITest)loader.RequestProvider(typeof (ITest));
        }
    }
    public class TestProvider : ITest
    {        
    }
