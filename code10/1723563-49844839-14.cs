    public interface IRepoFactory
    {
        IRepo GetRepository(); //you don't care about SQL server at all
        IRepo GetTestRepository(); //you don't care where test environment allocated
    }
    public class MyRepoFactory : IRepoFactory
    {
        public MyRepoFactory(string connectionString)
        {
           //...
        }
        //implementation
    }
