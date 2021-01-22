    public class Home {
      public static IRepository<T> For<T> {
        get {
          return Container.Resolve<IRepository<T>>();
        }
      }
    }
