    public class RuntimeDecoratorSelector : IDataReader
    {
        private readonly IDataReader decoratedDecoratee;
        private readonly IDataReader originalDecoratee;
        private readonly IRuntimeConfigProvider configProvider;
        public RuntimeDecoratorSelector(
            IDataReader decoratedDecoratee, IDataReader originalDecoratee,
            IRuntimeConfigProvider configProvider)
        {
            this.decoratedDecoratee = decoratedDecoratee;
            this.originalDecoratee = originalDecoratee;
            this.configProvider = configProvider;
        }
        private IDataReader Decoratee => 
            configProvider.Config.IncludeLineage ? decoratedDecoratee : originalDecoratee;
        // IDataReader methods
        public object DoSomething()
        {
            return Decoratee.DoSomething();
        }
    }
