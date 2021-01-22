    internal class BarModule : StandardModule {
      public override void Load() {
        Bind<IBar>()
          .To<BarClass>();
      }
    }
