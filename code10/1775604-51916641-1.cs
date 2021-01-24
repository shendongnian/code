    public interface IBaseRepository<E>
    {
        Task<T> Add<T>(E value,string typeName);
    }
    public class Test: IBaseRepository<SomeDefinedClass>
    {
        public Task<SomeClass> Add<SomeClass>(SomeDefinedClass value, string typeName)
        {
            throw new NotImplementedException();
        }
    }
