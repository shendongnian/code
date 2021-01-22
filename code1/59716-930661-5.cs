    public sealed class ExclamationPointTextDecorator : ITextDecorator
    {
        public string GetString(string input)
        {
            return input + "!";
        }
    }
    public sealed class ConditionalTextDecorator : ITextDecorator
    {
        private Func<bool> _condition;
        private ITextDecorator _innerTextDecorator;
        public ConditionalTextDecorator(Func<bool> condition, ITextDecorator innerTextDecorator)
        {
            _condition = condition;
            _innerTextDecorator = innerTextDecorator;
        }
        public string GetString(string input)
        {
            return _condition() ? _innerTextDecorator.GetString(input) : input;
        }
    }
