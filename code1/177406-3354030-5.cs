    public class TestingManager<T> : Manager<T> {
      public new ITestRepository<T> Repository {
        get {
          return (ITestRepository<T>)base.Repository;
        }
        set {
          base.Repository = value;
        }
      }
    }
