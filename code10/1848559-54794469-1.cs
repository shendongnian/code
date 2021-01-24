    interface IEchoFactory
    {
        IEcho GetEcho( string text );
    }
    class EchoFactory : IEchoFactory
    {
        public IEcho GetEcho(string text)
        {
            return new Echo(text);
        }
    }
    serviceCollection.AddTransient<IEchoFactory>( a=> new EchoFactory() );
