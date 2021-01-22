    public class Dog
    {
        public int Id { get; set; }
    }
    public interface IGetById<TEntity>
    {
        TEntity GetById(int id);
    }
    public interface IDogRepository : IGetById<Dog> { }
    public class DogRepository : IDogRepository
    {
        public Dog GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
    [ServiceContract]
    public interface IWcfService : IGetById<Dog>
    {
        [OperationContract(Name="GetDogById")]
        new Dog GetById(int id);
    }
