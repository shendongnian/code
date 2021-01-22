    namespace myProject.Abstract
    {
        public interface ISeriesRepository
        {
            IQueryable<Series> Series { get; }
        }
    }
