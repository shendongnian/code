    public interface IMyClassRepository
    {
        public MyClass GetById(int id);
    }
    public class MyClassRepository : IMyClassRepository
    {
        public MyClass GetById(int id)
        {
            // Some Implementation
        }
    }
    public class MyController
    {
        private IMyClassRepository _repo;
        public class MyController() : base(new MyClassRepository()) { }
  
        public class MyController(IMyClassRepository repo) { _repo = repo; }
    }
