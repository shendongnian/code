    public interface IRepo<TRepo>
    {
    }
    public interface ITypeEntity
    {
    }
    public class ClassA<T> where T : ITypeEntity
    {
        ClassB<T> b = new ClassB<T>();
        public void MethodA(IRepo<T> repo)
        {
            b.MethodB(repo);
        }
    }
    public class ClassB<T> where T : ITypeEntity
    {
        IRepo<T> repo;
        public void MethodB(IRepo<T> repo)
        {
            this.repo = repo;
        }
    }
