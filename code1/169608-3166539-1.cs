    public class MyClassRepository
    {
        public MyClass GetById(int id)
        {
            // Some Implementation
        }
    }
    public class MyController
    {
        private MyClassRepository _repo;
        public class MyController() : base(new MyClassRepository()) { }
  
        public class MyController(MyClassRepository repo) { _repo = repo; }
    }
