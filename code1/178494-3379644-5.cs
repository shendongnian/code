    public class MovieRepository : IMovieRepository
    {
        private Repository _repository;
        public MovieRepository(Repository repository)
        {
            _repository = repository;
        }
        public IList<Movie> GetByYear(int year)
        {
            Func<ISession, IList<Movie> query = session =>
            {
                var query = session.CreateQuery("from Movie"); //or
                var query = session.CreateCriteria("from Movie"); //or
                var query = session.Linq<Movie>();
                //set criteria etc.
                return query.List<Movie>(); //ToList<Movie>() if you're using Linq2NHibernate
            }:
            return _repository.WrapQueryInSession(query);
        }
    }
