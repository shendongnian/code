    public class DoSomethingAggregateFactory
    {
        public IDoSomethingAggregate Create()
        {
            return new DoSomethingAggregate(GetItems());
        }
    
        private IEnumerable<IDoSomethingAble> GetItems()
        {
            yield return new Service1();
            yield return new Service2();
            yield return new Service3();
            yield return new Service4();
            yield return new Service5();
        }
    }
