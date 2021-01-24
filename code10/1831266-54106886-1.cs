    public interface IExchangeProvider
    {
        IExchange CreateExchange(string exchangeName);
    }
    public class Exchange1Provider : IExchangeProvider
    {
        public IExchange CreateExchange(string exchangeName)
        {
            if(exchangeName == nameof(Exchange1))
            {
                // new it, resolve it from DI, use activation whatever suits your need
                return new Exchange1();
            }
            return null;
        }
    }
    public class Exchange2Provider : IExchangeProvider
    {
        public IExchange CreateExchange(string exchangeName)
        {
            if (exchangeName == nameof(Exchange2))
            {
                // new it, resolve it from DI, use activation whatever suits your need
                return new Exchange1();
            }
            return null;
        }
    }
    public class LazyExchangeFactory : IExchangeFactory
    {
        private readonly IEnumerable<IExchangeProvider> exchangeProviders;
        public LazyExchangeFactory(IEnumerable<IExchangeProvider> exchangeProviders)
        {
            this.exchangeProviders = exchangeProviders ?? throw new ArgumentNullException(nameof(exchangeProviders));
        }
        public IExchange CreateExchange(string exchangeName)
        {
            // This approach is lazy. The providers could be singletons etc. (avoids allocations)
            // and new instance will only be created if the parameters are matching
            foreach (IExchangeProvider provider in exchangeProviders)
            {
                IExchange exchange = provider.CreateExchange(exchangeName);
                // if the provider couldn't find a matcing exchange, try next provider
                if (exchange != null)
                {
                    return exchange;
                }
            }
            throw new ArgumentException($"No Exchange found for '{exchangeName}'.");
        }
    }
