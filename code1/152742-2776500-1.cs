    public class SqlCarRepository : ICarRepository
    {
        private CarDataContext _context;
        public SqlCarRepository()
        {
            _context = new CarDataContext();
        }
        #region ICarRepository Members
        public IQueryable<Car> GetAllCars()
        {
            return _context.Cars;
        }
