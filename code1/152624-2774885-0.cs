    public class Service
    {
        public IServiceSize serviceSize { internal get; set; }
        public IServiceBulkRate serviceBulkRate { internal get; set; }
        public IServiceType serviceType { internal get; set; }
        public int numberOfProducts { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class with default values
        /// </summary>
        public Service()
        {
            serviceSize = new SmallSize();
            serviceBulkRate = new FlatBulkRate();
            serviceType = new WritingService();
            numberOfProducts = 1;
        }
        public decimal CalculateHours()
        {
            decimal hours = serviceSize.GetBaseHours();
            hours = hours * serviceBulkRate.GetMultiplier(numberOfProducts);
            hours = hours * serviceType.GetMultiplier();
            return hours;
        }
    }
    public interface IServiceSize
    {
        int GetBaseHours();
    }
    public class SmallSize : IServiceSize
    {
        public int GetBaseHours()
        {
            return 125;
        }
    }
    public interface IServiceBulkRate
    {
        decimal GetMultiplier(int numberOfProducts);
    }
    public class FlatBulkRate : IServiceBulkRate
    {
        public decimal GetMultiplier(int numberOfProducts)
        {
            return numberOfProducts;
        }
    }
    public class StaggeredBulkRate : IServiceBulkRate
    {
        public decimal GetMultiplier(int numberOfProducts)
        {
            if (numberOfProducts < 2)
                return numberOfProducts;
            else if (numberOfProducts >= 2 & numberOfProducts < 8)
                return numberOfProducts * 0.85m;
            else
                return numberOfProducts * 0.8m;
        }
    }
    public interface IServiceType
    {
        decimal GetMultiplier();
    }
    public class WritingService : IServiceType
    {
        public decimal GetMultiplier()
        {
            return 1.15m;
        }
    }
