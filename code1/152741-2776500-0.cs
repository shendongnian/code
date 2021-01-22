     public interface ICarRepository
     {
        IQueryable<Car> GetAllCars();
        void Add(Car);
     }
