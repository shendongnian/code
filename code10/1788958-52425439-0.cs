    class SentimentEngineConsumer
    {
        ISentimentEngine _engine;
        public SentimentEngineConsumer(ISentimentEngine engine)
        {
            _engine = engine;
        }
        ...
    }
