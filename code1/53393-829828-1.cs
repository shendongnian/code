    public interface ILoader
    {
        IProvider RequestProvider(Type providerType);
    }
    public interface IConsumer
    {
        void Initialize(ILoader loader);
    }
    public interface IProvider
    {
    }
