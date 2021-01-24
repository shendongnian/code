    public interface IBaseRepository
    {
        Task<T> Add<T>(string value,string typeName);
        Task<T> Add<T>(int value,string typeName);
        Task<T> Add<T>(bool value,string typeName);
    }
    public class Test: IBaseRepository
    {
        public Task<SomeClass> Add<SomeClass>(string value, string typeName)
        {
            throw new NotImplementedException();
        }
        public Task<SomeClass> Add<SomeClass>(int value, string typeName)
        {
            throw new NotImplementedException();
        }
        public Task<SomeClass> Add<SomeClass>(bool value, string typeName)
        {
            throw new NotImplementedException();
        }
    }
