    public interface IReadRepository {
        public void Select();
    }
    
    public interface IWriteRepository {
        public void Insert();
        public void Update();
        public void Delete();
    }
    // Optional
    public interface IRepository : IReadRepository, IWriteRepository {
    }
    
    public class Repository : IRepository {
       // Implementation
    }
