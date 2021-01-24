    public class Aggregator
    {
        public void Aggregate(Order order, Dictionary<OrderTypeEnum, Aggregate> aggregates)
        {
            var aggregate = aggregates[order.OrderType];
            Interlocked.Increment(ref aggregate.Count);
        }
    }
