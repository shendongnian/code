    class Program
    {
        static void Main(string[] args)
        {
            var expectedReturn = new List<Product> { new Product { StockNumber = "123" } };
            var provider = new Mock<IProvider>();
            provider
                .Setup(x => x.Run(
                    It.IsAny<Func<IRemoteClient, Task<List<Product>>>>(),
                    It.IsAny<string>()))
                .ReturnsAsync(expectedReturn);
            var result = provider.Object.Run(client => client.GetAsync<List<Product>>(null), "foo");
            Console.WriteLine(result.Result[0].StockNumber);
        }
    }
    public interface IProvider
    {
        Task<T> Run<T>(Func<IRemoteClient, Task<T>> action, string name);
    }
    public interface IRemoteClient
    {
        Task<T> GetAsync<T>(object request);
    }
    public class Product
    {
        public string StockNumber { get; set; }
    }
