    ObjectFactory.Initialize(x => {
      x.Scan(y =>
      {
          y.TheCallingAssembly();
          y.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
        });
    });
