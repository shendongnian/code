    public interface IService {}
    public interface ICustomerService : IService {}
    public class CustomerService : ICustomerService {}
    public interface ISupplerService : IService {}
    public class SupplierService : ISupplerService {}
    public static class MyService
    {
        public static T GetService<T>() where T : IService
        {
            object service;
            var t = typeof(T);
            if (t == typeof(ICustomerService))
            {
                service = new CustomerService();
            }
            else if (t == typeof(ISupplerService))
            {
                service = new SupplierService();
            }
            // etc.
            else
            {
                throw new Exception();
            }
            return (T)service;
        }
    }
