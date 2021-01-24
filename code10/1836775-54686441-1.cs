    internal class GuidQuery<T> : QueryHandler<T> where T : class
    {
        public override Type[] Types => new Type[] { typeof(Guid), typeof(Guid?) };
        public GuidQuery(//Properties) : base(//Properties)
        {
        }
        public override IQueryable<T> Handle()
        {
            // Implementation
        }
    }
