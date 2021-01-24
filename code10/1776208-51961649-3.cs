    public class CompositeQuoteProcessor : IQuoteProcessor
    {
        private readonly IReadOnlyCollection<IQuoteProcessor> processors;
        public CompositeQuoteProcessor(params IQuoteProcessor[] processors)
        {
            this.processors = processors ?? throw new ArgumentNullException(nameof(processors));
        }
        public Quote ProcessQuote(Quote quote)
        {
            var q = quote;
            foreach (var p in processors)
                q = p.ProcessQuote(q);
            return q;
        }
    }
