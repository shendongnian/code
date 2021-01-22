    public class MyLibraryModule : StandardModule {
      public override void Load() {
        Bind<IMyService>()
          .To<ServiceImpl>();
        // ... more bindings ...
      }
    }
