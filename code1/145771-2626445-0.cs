        public DataService : IDataService
        {
            private IDataService _provider;
            
            public DataService()
            {
                _provider = new RealService();
            }
            public DataService(IDataService provider)
            {
                _provider = provider;
            }
            public object GetAllQuestions()
            {
                return _provider.GetAllQuestions();
            }
        }
