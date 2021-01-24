    public class LineageIdDecorator : IDataReader
    {
        public LineageIdDecorator(
            IDataReader decoratee, IRuntimeConfigProvider configProvider) { .. }
        // IDataReader methods
        public object DoSomething()
        {
            if (configProvider.Config.IncludeLineage)
            {
                // run decorated behavior
            }
            return decoratee.DoSomething();
        }
    }
