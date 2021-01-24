    builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .Where(type => type.Name.EndsWith("ViewModel"))
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace) && type.Namespace.Contains("ViewModels"))
                .Where(type => !type.IsAssignableFrom(typeof(INotificationHandler<>)))
                .AssignableTo<INotifyPropertyChanged>()
                .AsSelf()
                .InstancePerDependency();
