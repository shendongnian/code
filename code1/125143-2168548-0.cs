    container.Register(Component.For<Consumer>()
                   .DynamicParameters((kernel, parameters) => 
                       parameters["services"] = new Dictionary<string, IService> {
                         {"one", kernel.Resolve<IService>("service1")},
                         {"two", kernel.Resolve<IService>("service2")},
                       }
                   ));
