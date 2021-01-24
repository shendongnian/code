    public interface IBaseRepository<T,U,V>
    {
        Task<V> AddData(T namespaceName, U typeName);
    }
    
    public class SomeClass
    {
    }
    public class Test : IBaseRepository<string, string, SomeClass> , IBaseRepository<int,string,SomeClass>
    {
        public Task<SomeClass> AddData(int namespaceName, string typeName)
        {
            throw new NotImplementedException();
        }
        public Task<SomeClass> AddData(string namespaceName, string typeName)
        {
            throw new NotImplementedException();
        }
    }
