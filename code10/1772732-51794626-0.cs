    var container = new WindsorContainer();
    container.Register(
        Classes.FromThisAssembly()
            .BasedOn(typeof(IMyInterface<>))
            .Configure(x =>
            {
                var iMyInterfaceImpl = x.Implementation;
                
                var iMyInterface = iMyInterfaceImpl
                    .GetTypeInfo()
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMyInterface<>))
                    .Single();
                    
                var iMyInterfaceGenericArg0 = iMyInterface.GetGenericArguments()[0];
                
                var myClassImpl = typeof(MyClass<,>).MakeGenericType(iMyInterfaceImpl, iMyInterfaceGenericArg0);
                var iMyClass = typeof(IMyClass<>).MakeGenericType(iMyInterfaceGenericArg0);
                
                container.Register(Component.For(iMyClass).ImplementedBy(myClassImpl));
            })
    );
    
    
    container.Resolve(typeof(IMyClass<string>)); // MyClass<MyImplementation, string>
