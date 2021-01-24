    interface IEchoFactory
    {
        IEcho GetEcho();
    }
    class EchoFactory : IEchoFactory
    {
        public IEcho GetEcho(string text)
        {
            return new Echo(text);
        }
    }
    serviceCollection.AddTransient<IEchoFactory>( a=> new EchoFactory() );
