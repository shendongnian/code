    public class Aggregator
    {
        private static readonly Object _lockObj = new Object();
        public void Aggregate(Order order, Dictionary<OrderTypeEnum, Aggregate> aggregates)
        {
            lock (_lockObj)
            {
                aggregates[order.OrderType].Count++;
            }
        }
    }
