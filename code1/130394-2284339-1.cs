    public class TestDateTimeProvider: IDateTimeProvider
    {
        private DateTime timeToProvide;
        public TestDateTimeProvider(DateTime timeToProvide)
        {
            this.timeToProvide = timeToProvide;
        }
        public DateTime Now
        {
            get
            {
                return timeToProvide;
            }
        }
    }
