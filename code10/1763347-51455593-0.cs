    public class Aggregator
    {
        public void Aggregate(Order order, Dictionary<OrderTypeEnum, Aggregate> aggregates)
        {
            Interlocked.Increment(ref aggregates[order.OrderType].Count);
        }
    }
