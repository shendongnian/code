    public class Customer : Reference<Customer>, IHistoricalItem
    {
    }
    public class Address : Reference<Address>, IHistoricalItem
    {
    }
    public interface IHistoricalItem
    {
    }
    public class Reference<T> where T : IHistoricalItem, new()
    {
        public static T GetHistoricItem(int id, DateTime pastDateTime)
        {
            return new T();
        }
    }
