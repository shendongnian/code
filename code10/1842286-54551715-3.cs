    public class Consumer
    {
        private readonly Wrapper _data;
        public Consumer(Wrapper data) => _data = data;
        public void DoSomething()
        {
            var myProducts = _data.Products.GetMy();
            // ...
        }
    }
