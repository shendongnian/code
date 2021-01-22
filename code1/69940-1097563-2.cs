    namespace myProject
    {
        public class SeriesProcessor
        {
            private ISeriesRepository seriesRepository;
    
            public void SeriesProcessor(ISeriesRepository seriesRepository)
            {
                this.seriesRepository = seriesRepository;
            }
    
            public IQueryable<Series> GetCurrentSeries()
            {
                return from s in seriesRepository.Series
                       where s.openingDate.Date <= DateTime.Now.Date
                       select s;
            }
        }
    }
