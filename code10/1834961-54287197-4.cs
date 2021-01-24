    public class ConsumerOfSb
    {
        private readonly ISbFactory _sbFactory;
        public ConsumerOfSb(ISbFactory sbFactory) => _sbFactory = sbFactory;
        public void Execute()
        {
            var sb = _sbFactory.Create();
            sb.ExecuteActionOne();
        }
    }
