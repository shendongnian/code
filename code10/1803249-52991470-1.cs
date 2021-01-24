    public class PipelineX<T> : FilterBase<T>, IPipelineX<T>
    {
        private readonly FilterFactory _factory;
        public PipelineX(FilterFactory factory)
        {
            _factory = factory;
        }
        protected override T Process(T input)
        {
            return input;
        }
        public PipelineX<T> FilterBy<X>()
        {
            var filter = _factory.Create<X,T>() as IFilter<T>;
            Register(filter);
            return this;
        }
    }
