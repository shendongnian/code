    public class SomethingClient<T>
    {
        private readonly Func<T> somethingFactory;
        public SomethingClient(Func<T> aSomethingFactory)
        {
            somethingFactory = aSomethingFactory;
        }
        public void SomeDynamicScenario()
        {
            var something = repositoryFactory();
            //operate on new object
        }
    }
    
