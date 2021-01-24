    public interface IDoSomethingAggregate : IDoSomethingAble {}
    public class DoSomethingAggregate : IDoSomethingAggregate 
    {
        private IEnumerable<IDoSomethingAble> somethingAbles;
        public class DoSomethingAggregate(IEnumerable<IDoSomethingAble> somethingAbles)
        {
            _somethingAbles = somethingAbles;
        }
        public Quote DoSomething(Quote quote)
        {
            foreach(var somethingAble in _somethingAbles)
            {
                somethingAble.DoSomething(quote);
            }
            return quote;
        }
    }
