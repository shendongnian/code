    private void RegisterDecorators(ContainerBuilder builder, Assembly assembly, object[] tags)
    {
       List<Type> decorableServices = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service")
                                                                              && t.GetInterface(nameof(IDecorableService)) != null
                                                                              && t.GetInterface(nameof(IServiceDecorator)) == null).ToList();
    
    
       foreach (Type type in decorableServices)
       {
          Type baseType = type.GetInterfaces().FirstOrDefault(x => x.Name.EndsWith(type.Name));
          if (baseType == null)
          {
             builder.RegisterType(type)
                    .AsSelf()
                    .InstancePerMatchingLifetimeScope(tags);
             break;
          }
    
          MethodInfo mi = this.GetType().GetMethod(nameof(RegisterDecoratedService), BindingFlags.NonPublic | BindingFlags.Instance);
          MethodInfo gmi = mi.MakeGenericMethod(baseType, type);
          gmi.Invoke(this, new object[] {builder, assembly, tags});
       }
    }
    
   
    private void RegisterDecoratedService<TInterface, TImplementation>(ContainerBuilder builder, Assembly assembly, object[] tags)
       {
          List<Type> decorators = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service")
                                                                           && t.GetInterface(typeof(TInterface).Name) != null
                                                                           && t.GetInterface(nameof(IServiceDecorator)) != null)
                        .OrderBy(t =>
                        {
                            DecorationOrderAttribute order = t.GetCustomAttribute<DecorationOrderAttribute>();
                            return order?.Order ?? 0;
                        }).ToList();
        
          if (!decorators.Any())
          {
             builder.RegisterType<TImplementation>()
                    .As<TInterface>()
                    .InstancePerMatchingLifetimeScope(tags);
          }
          else
          {
             string implName = typeof(TImplementation).Name;
        
             builder.RegisterType<TImplementation>()
                    .Named<TInterface>(implName)
                    .InstancePerMatchingLifetimeScope(tags);
                        
             for (int i = 0; i < decorators.Count; i++)
             {
                string decoratorKey = decorators[i].FullName;
                string fromKey = (i == 0) ? implName : $"{implName}Decorator{i}";
                string toKey = $"{implName}Decorator{i + 1}";
                            
                builder.RegisterType(decorators[i])
                       .Named<TInterface>(decoratorKey)
                       .InstancePerMatchingLifetimeScope(tags);
        
                if (i != decorators.Count - 1)
                {
                   builder.RegisterDecorator<TInterface>((c, inner) => c.ResolveNamed<TInterface>(decoratorKey, TypedParameter.From(inner)), fromKey, toKey)
                                    .InstancePerMatchingLifetimeScope(tags);
                 }
                 else
                 {
                     builder.RegisterDecorator<TInterface>((c, inner) => c.ResolveNamed<TInterface>(decoratorKey, TypedParameter.From(inner)), fromKey)
                                    .InstancePerMatchingLifetimeScope(tags);
                  }
               }
            }
         }
