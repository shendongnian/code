    var repoTypes = asm.GetTypes().Where(x =>
                                             !x.IsInterface && !x.IsAbstract && x.IsClass &&
                                             !x.IsGenericType &&
                                             x.GetInterfaces().All(y => !y.IsGenericType || !reportRepo.IsAssignableFrom(y.GetGenericTypeDefinition())) &&
                                             x.GetInterfaces().Any(y => y.IsGenericType &&
                                                                        repoInterfaceType.IsAssignableFrom(y.GetGenericTypeDefinition())))
                       .ToList();
