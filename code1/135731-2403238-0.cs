    public class ExampleClass
    {
        public int TestProperty { get; set; }
    }
    
    public interface IRepository
    {
        ExampleClass Load(int id);
        int Save();
    }
    
    public class RepositorySql: IRepository
    {
        // implement the two methods using sql
    }
