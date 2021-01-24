        private void RegisterDecoratedService<TInterface, TImplementation>(ContainerBuilder builder, Assembly assembly, Type baseType, Type implType, object[] tags)
        {
           List<Type> decorators = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service")
                                                                           && t.GetInterface(baseType.Name) != null
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
              builder.RegisterType<TImplementation>()
                     .Named<TInterface>(implType.Name)
                     .InstancePerMatchingLifetimeScope(tags);
                        
              for (int i = 0; i < decorators.Count; i++)
              {
                 string decoratorKey = decorators[i].FullName;
                 string fromKey = (i == 0) ? implType.Name : $"{implType.Name}Decorator{i}";
                 string toKey = $"{implType.Name}Decorator{i + 1}";
                            
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
