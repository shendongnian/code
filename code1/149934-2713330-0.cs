    if (appConfigIndicatesMockMode()){
      ForRequestedType<IRepository>().TheDefaultIsConcreteType<MockRepository>()
    } else {
      ForRequestedType<IRepository>().TheDefaultIsConcreteType<RealRepository>()
    }
