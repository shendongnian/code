    public class Service : IDisposable
    {
        private IBus _bus;
        public void Initialize()
        {
            _bus = RabbitHutch.CreateBus("host=your-rabbitmq-node");
            _bus.Subscribe<NewProductMessage>("test", HandleNewProduct);
        }
        void HandleNewProduct(NewProductMessage newProduct)
        {
            SendUserNotifiaction(newProduct);
            ProcessProductOrder(newProduct);
        }
        // Some service logic here...
        // SendUserNotifiaction
        // ProcessProductOrder
        public void Dispose()
        {
            _bus?.Dispose();
        }
    }
