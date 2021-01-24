    container.RegisterConditional(
      typeof(IMyInterface), c => {
          var instance = new MyClass();
          return new MyCachedClass(instance, TimeSpan.FromMinutes(5));
        }, Lifestyle.Singleton, c => true);
