    public class DeviceHistoryRepository : IDeviceHistoryRepository
    {
          
        public DeviceHistoryRepository(DbContext context)
        {
             Context = context;
        }
        public IEnumerable<Course> GetBillOfMaterialById(string productId)
        {
            return dbContext.Products.FirstOrDefault(p => p.ProductId == ProductId);
        }
    }
